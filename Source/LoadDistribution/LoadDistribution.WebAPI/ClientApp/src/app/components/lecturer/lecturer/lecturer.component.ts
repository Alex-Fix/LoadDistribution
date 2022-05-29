import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import UniversityLecturerMapClient from 'src/app/clients/universityLecturerMapClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';
import UniversityLecturerMapDTO from 'src/app/models/dto/models/universityLecturerMapDTO.model';
import OperationManager from 'src/app/helpers/operationManager.helper';
import { mergeMap } from 'rxjs/operators';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-lecturer',
  templateUrl: './lecturer.component.html',
  styleUrls: ['./lecturer.component.scss']
})
export class LecturerComponent extends CUComponent<LecturerDTO> {
  private _universities: UniversityDTO[];

  operationManager = new OperationManager<UniversityLecturerMapDTO>(
    this._universityLecturerMapClient,
    dto => this._initUniversityLecturerMapForm(dto)
  );
  
  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _universityClient: UniversityClient,
    private readonly _universityLecturerMapClient: UniversityLecturerMapClient,
    private readonly _lecturerClient: LecturerClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(_lecturerClient, activatedRoute, router, '/lecturers');
    
    this.id$.subscribe(id => this._onIdChanged(id));
    this._universityClient.getAll().subscribe(u => this._universities = u);
  }

  onCreateButtonClick(): void {
    this._lecturerClient
      .insert(this._payloadMapper())
      .pipe(
        mergeMap(({id}) => {
          return this.operationManager.synchronize((dto, form) => { 
            return {...dto, ...form.value, lecturerId: id, university: null, lecturer: null};
          });
        })
      ).subscribe(() => {
        this.operationManager.clear();
        this._initForm();
      });
  }

  onCreateAndReturnButtonClick(returnUrl: string | null = null): void {
    this._lecturerClient
        .insert(this._payloadMapper())
        .pipe(
          mergeMap(({id}) => {
            return this.operationManager.synchronize((dto, form) => {
              return {...dto, ...form.value, lecturerId: id, university: null, lecturer: null};
            });
          })
        ).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  onUpdateButtonClick(): void {
    forkJoin([
      this._lecturerClient.update(this._payloadMapper()),
      this.operationManager.synchronize((dto, form) => {
        return {...dto, ...form.value, lecturerId: this.base.id, university: null, lecturer: null};
      })
    ]).subscribe(() => {
      this.operationManager.clear();
      this._initForm();
      this._tryLoadData(this.base.id);
    });
  }

  onUpdateAndReturnButtonClick(returnUrl: string | null = null): void {
    forkJoin([
      this._lecturerClient.update(this._payloadMapper()),
      this.operationManager.synchronize((dto, form) => {
        return {...dto, ...form.value, lecturerId: this.base.id, university: null, lecturer: null};
      })
    ]).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  filterUniversities(control: FormGroup): UniversityDTO[] {
    return this._universities.filter(u => !this.operationManager.controls.some(c => c != control && c.value.universityId == u.id));
  }

  protected _payloadMapper(): any {
    return {...this.base, ...this.form.value, universityLecturerMaps: null};
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      lastName: new FormControl(null, [Validators.required]),
      firstName: new FormControl(null, [Validators.required]),
      middleName: new FormControl(null, [Validators.required]),
      universityLecturerMaps: this.operationManager.formArray
    });
  }

  private _initUniversityLecturerMapForm(dto: UniversityLecturerMapDTO | null): FormGroup {
    return this._formBuilder.group({
      universityId: new FormControl(dto?.universityId, [Validators.required])
    });
  }

  private _onIdChanged(id: number): void {
    this._universityLecturerMapClient.search(id).subscribe(ulms => 
      this.operationManager.addRange(ulms)
    );
  }
}
