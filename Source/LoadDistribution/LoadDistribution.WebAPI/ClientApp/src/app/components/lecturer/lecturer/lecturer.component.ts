import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import UniversityLecturerMapClient from 'src/app/clients/universityLecturerMapClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';

@Component({
  selector: 'app-lecturer',
  templateUrl: './lecturer.component.html',
  styleUrls: ['./lecturer.component.scss']
})
export class LecturerComponent extends CUComponent<LecturerDTO> {
  universities$: Observable<UniversityDTO[]> = this._universityClient.getAll();

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _universityClient: UniversityClient,
    private readonly _universityLecturerMapClient: UniversityLecturerMapClient,
    lecturerClient: LecturerClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(lecturerClient, activatedRoute, router, '/lecturers');
    this.id$.subscribe(id => this._onIdChanged(id));
  }

  get universityLecturerMapsFormArray(): FormArray {
    return this.form.get("universityLecturerMaps") as FormArray;
  }

  addUniversityLecturerMap(universityId: number | null = null): void {
    this.universityLecturerMapsFormArray.push(this._formBuilder.group({
      universityId: new FormControl(universityId, [Validators.required])
    }));
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      lastName: new FormControl(null, [Validators.required]),
      firstName: new FormControl(null, [Validators.required]),
      middleName: new FormControl(null, [Validators.required]),
      universityLecturerMaps: this._formBuilder.array([])
    });
  }

  private _onIdChanged(id: number): void {
    this._universityLecturerMapClient.search(id).subscribe(ulms => {
      ulms.forEach(ulm => this.addUniversityLecturerMap(ulm.universityId));
    });
  }
}
