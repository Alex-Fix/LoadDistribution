import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { merge, Observable } from 'rxjs';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import UniversityLecturerMapClient from 'src/app/clients/universityLecturerMapClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';
import UniversityLecturerMapDTO from 'src/app/models/dto/models/universityLecturerMapDTO.model';
import OperationManager from 'src/app/helpers/operationManager.helper';
import SynchronizationManager from 'src/app/helpers/synchronizationManager.helper';
import { last, tap } from 'rxjs/operators';

@Component({
  selector: 'app-lecturer',
  templateUrl: './lecturer.component.html',
  styleUrls: ['./lecturer.component.scss']
})
export class LecturerComponent extends CUComponent<LecturerDTO> {
  private _synchronizationManager = new SynchronizationManager<UniversityLecturerMapDTO>(this._universityLecturerMapClient, dto => {
    return {...dto, lecturerId: this.base.id };
  });

  universities: UniversityDTO[];

  operationManager = new OperationManager<UniversityLecturerMapDTO>(ulm => this._formBuilder.group({
    universityId: new FormControl(ulm?.universityId, [Validators.required])
  }));
  
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
    this._universityClient.getAll().subscribe(us => this.universities = us);
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      lastName: new FormControl(null, [Validators.required]),
      firstName: new FormControl(null, [Validators.required]),
      middleName: new FormControl(null, [Validators.required]),
      universityLecturerMaps: this.operationManager.formArray
    });
  }

  onCreateButtonClick(): void {
    merge(
      this._lecturerClient.insert(this.form.value),
      this._synchronizationManager.synchronize(this.operationManager)
    ).subscribe(() => {
      this._initForm();
      this.operationManager.clear();
    });
  }

  onCreateAndReturnButtonClick(returnUrl: string | null = null): void {
    merge(
      this._lecturerClient.insert(this.form.value),
      this._synchronizationManager.synchronize(this.operationManager)
    ).subscribe(() => this._router.navigateByUrl(returnUrl ?? this._returnUrl));
  }

  onUpdateButtonClick(): void {
      const updatedEntity = {...this._payloadMapper(this.base), ...this.form.value};

      merge(
        this._lecturerClient.update(updatedEntity),
        this._synchronizationManager.synchronize(this.operationManager)
      ).pipe(
        last()
      ).subscribe(() => 
        this._universityLecturerMapClient.search(this.base.id)
        .subscribe(ulms => {
          this.operationManager.clear();
          this.operationManager.addRange(ulms)
        })
      );
  }

  onUpdateAndReturnButtonClick(returnUrl: string | null = null): void {
      const updatedEntity = {...this._payloadMapper(this.base), ...this.form.value};

      merge(
        this._lecturerClient.update(updatedEntity),
        this._synchronizationManager.synchronize(this.operationManager)
      ).subscribe(() => 
          this._router.navigateByUrl(returnUrl ?? this._returnUrl)
      );
  }

  private _onIdChanged(id: number): void {
    this._universityLecturerMapClient.search(id).subscribe(ulms => 
      this.operationManager.addRange(ulms)
    );
  }
}
