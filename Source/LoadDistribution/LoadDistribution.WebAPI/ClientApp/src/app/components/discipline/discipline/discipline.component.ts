import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { mergeMap } from 'rxjs/operators';
import ActivityClient from 'src/app/clients/activityClient.client';
import DisciplineActivityMapClient from 'src/app/clients/disciplineActivityMapClient.client';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import OperationManager from 'src/app/helpers/operationManager.helper';
import ActivityDTO from 'src/app/models/dto/models/activityDTO.model';
import DisciplineActivityMapDTO from 'src/app/models/dto/models/disciplineActivityMapDTO.model';
import DisciplineDTO from 'src/app/models/dto/models/disciplineDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';

@Component({
  selector: 'app-discipline',
  templateUrl: './discipline.component.html',
  styleUrls: ['./discipline.component.scss']
})
export class DisciplineComponent extends CUComponent<DisciplineDTO> {
  private _activities: ActivityDTO[];

  universities$: Observable<UniversityDTO[]> = this._universityClient.getAll();
  
  operationManager = new OperationManager<DisciplineActivityMapDTO>(
    this._disciplineActivityMapClient,
    dto => this._initDisciplineActivityMapForm(dto)
  );

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _universityClient: UniversityClient,
    private readonly _disciplineActivityMapClient: DisciplineActivityMapClient,
    private readonly _disciplineClient: DisciplineClient,
    private readonly _activityClient: ActivityClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(_disciplineClient, activatedRoute, router, '/disciplines');

    this.id$.subscribe(id => this._onIdChanged(id));
    this._activityClient.getAll().subscribe(a => this._activities = a);
  }

  onCreateButtonClick(): void {
    this._disciplineClient
      .insert(this._payloadMapper())
      .pipe(
        mergeMap(({id}) => {
          return this.operationManager.synchronize((dto, form) => { 
            return {...dto, ...form.value, disciplineId: id, disciplineActivityMaps: null};
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
              return {...dto, ...form.value, disciplineId: id, disciplineActivityMaps: null};
            });
          })
        ).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  onUpdateButtonClick(): void {
    forkJoin([
      this._disciplineClient.update(this._payloadMapper()),
      this.operationManager.synchronize((dto, form) => {
        return {...dto, ...form.value, disciplineId: this.base.id, disciplineActivityMaps: null};
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
        return {...dto, ...form.value, disciplineId: this.base.id, disciplineActivityMaps: null};
      })
    ]).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  filterActivities(control: FormGroup): UniversityDTO[] {
    return this._activities.filter(a => !this.operationManager.controls.some(c => c != control && c.value.activityId == a.id));
  }

  protected _payloadMapper(): any {
    return {...this.base, ...this.form.value, university: null};
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
      disciplineActivityMaps: this.operationManager.formArray
    });
  }

  private _initDisciplineActivityMapForm(dto: DisciplineActivityMapDTO | null): FormGroup {
    return this._formBuilder.group({
      activityId: new FormControl(dto?.activityId, [Validators.required]),
      value: new FormControl(dto?.value, [Validators.required])
    });
  }

  private _onIdChanged(id: number): void {
    this._disciplineActivityMapClient.search(id).subscribe(dams => 
      this.operationManager.addRange(dams)
    );
  }
}
