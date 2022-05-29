import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { mergeMap } from 'rxjs/operators';
import ActivityClient from 'src/app/clients/activityClient.client';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import LecturerDisciplineActivityMapClient from 'src/app/clients/lecturerDisciplineActivityMapClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import OperationManager from 'src/app/helpers/operationManager.helper';
import ActivityDTO from 'src/app/models/dto/models/activityDTO.model';
import DisciplineDTO from 'src/app/models/dto/models/disciplineDTO.model';
import LecturerDisciplineActivityMapDTO from 'src/app/models/dto/models/lecturerDisciplineActivityMapDTO.model';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';

@Component({
  selector: 'app-discipline',
  templateUrl: './discipline.component.html',
  styleUrls: ['./discipline.component.scss']
})
export class DisciplineComponent extends CUComponent<DisciplineDTO> {
  private _lecturers: LecturerDTO[];
  private _activities: ActivityDTO[];

  operationManager = new OperationManager<LecturerDisciplineActivityMapDTO>(
    this._lecturerDisciplineActivityMapClient,
    dto => this._initLecturerDisciplineActivityMapForm(dto)
  );

  universities$: Observable<UniversityDTO[]> = this._universityClient.getAll();
  
  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _universityClient: UniversityClient,
    private readonly _lecturerDisciplineActivityMapClient: LecturerDisciplineActivityMapClient,
    private readonly _lecturerClient: LecturerClient,
    private readonly _activityClient: ActivityClient,
    private readonly _disciplineClient: DisciplineClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(_disciplineClient, activatedRoute, router, '/disciplines');

    this.id$.subscribe(id => this._onIdChanged(id));
    this._lecturerClient.getAll().subscribe(l => this._lecturers = l);
    this._activityClient.getAll().subscribe(a => this._activities = a); 
  }

  onCreateButtonClick(): void {
    this._disciplineClient
      .insert(this._payloadMapper())
      .pipe(
        mergeMap(({id}) => {
          return this.operationManager.synchronize((dto, form) => { 
            return {...dto, ...form.value, disciplineId: id, discipline: null, lecturer: null, activity: null};
          });
        })
      ).subscribe(() => {
        this.operationManager.clear();
        this._initForm();
      });
  }

  onCreateAndReturnButtonClick(returnUrl: string | null = null): void {
    this._disciplineClient
        .insert(this._payloadMapper())
        .pipe(
          mergeMap(({id}) => {
            return this.operationManager.synchronize((dto, form) => {
              return {...dto, ...form.value, disciplineId: id, discipline: null, lecturer: null, activity: null};
            });
          })
        ).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  onUpdateButtonClick(): void {
    forkJoin([
      this._disciplineClient.update(this._payloadMapper()),
      this.operationManager.synchronize((dto, form) => {
        return {...dto, ...form.value, disciplineId: this.base.id, discipline: null, lecturer: null, activity: null};
      })
    ]).subscribe(() => {
      this.operationManager.clear();
      this._initForm();
      this._tryLoadData(this.base.id);
    });
  }

  onUpdateAndReturnButtonClick(returnUrl: string | null = null): void {
    forkJoin([
      this._disciplineClient.update(this._payloadMapper()),
      this.operationManager.synchronize((dto, form) => {
        return {...dto, ...form.value, disciplineId: this.base.id, discipline: null, lecturer: null, activity: null};
      })
    ]).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  filterLecturers(control: FormGroup): LecturerDTO[] {
    return this._lecturers.filter(l =>
      this.operationManager.controls.filter(c => c != control && c.value.lecturerId == l.id).length != this._activities.length
      && !this.operationManager.controls.some(c => c != control && c.value.lecturerId == l.id && !!control.value.activityId && c.value.activityId == control.value.activityId)
    );
  }

  filterActivities(control: FormGroup): ActivityDTO[] {
    return this._activities.filter(a => 
      this.operationManager.controls.filter(c => c != control && c.value.activityId == a.id).length != this._lecturers.length
      && !this.operationManager.controls.some(c => c != control && c.value.activityId == a.id && control.value.lecturerId && c.value.lecturerId == control.value.lecturerId)
    );
  }

  protected _payloadMapper(): any {
    return {...this.base, ...this.form.value, university: null, lecturerDisciplineActivityMaps: null};
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      name: new FormControl(null, [Validators.required]),
      type: new FormControl(null),
      term: new FormControl(null, [Validators.required]),
      educationLevel: new FormControl(null),
      educationForm: new FormControl(null, [Validators.required]),
      planIndex: new FormControl(null, [Validators.required]),
      speciality: new FormControl(null, [Validators.required]),
      groupAbbreviation: new FormControl(null, [Validators.required]),
      specialization: new FormControl(null, [Validators.required]),
      institute: new FormControl(null),
      course: new FormControl(null, [Validators.required]),
      studentCount: new FormControl(null, [Validators.required]),
      budgetStudentCount: new FormControl(null, [Validators.required]),
      comercialStudentCount: new FormControl(null, [Validators.required]),
      groupCount: new FormControl(null, [Validators.required]),
      subgroupCount: new FormControl(null, [Validators.required]),
      threadCount: new FormControl(null, [Validators.required]),
      universityId: new FormControl(null, [Validators.required]),
      lecturerDisciplineActivityMaps: this.operationManager.formArray
    });
  }

  private _initLecturerDisciplineActivityMapForm(dto: LecturerDisciplineActivityMapDTO | null): FormGroup {
    return this._formBuilder.group({
      lecturerId: new FormControl(dto?.lecturerId, [Validators.required]),
      activityId: new FormControl(dto?.activityId, [Validators.required]),
      rate: new FormControl(dto?.rate, [Validators.required])
    });
  }

  private _onIdChanged(id: number) {
    this._lecturerDisciplineActivityMapClient.search(id).subscribe(ulms => 
      this.operationManager.addRange(ulms)
    );
  }
}
