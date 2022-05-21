import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import UniversityLecturerMapClient from 'src/app/clients/universityLecturerMapClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';
import UniversityLecturerMapDTO from 'src/app/models/dto/models/universityLecturerMapDTO.model';

@Component({
  selector: 'app-university-lecturer-map',
  templateUrl: './university-lecturer-map.component.html',
  styleUrls: ['./university-lecturer-map.component.scss']
})
export class UniversityLecturerMapComponent extends CUComponent<UniversityLecturerMapDTO> {
  universities$: Observable<UniversityDTO[]> = this._universityClient.getAll();
  lecturers$: Observable<LecturerDTO[]> = this._lecturerClient.getAll();

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _universityClient: UniversityClient,
    private readonly _lecturerClient: LecturerClient,
    universityLecturerMapClient: UniversityLecturerMapClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(universityLecturerMapClient, activatedRoute, router, '/universityLecturerMaps');
  }

  protected _payloadMapper(): any {
    return {...this.base, ...this.form.value, university: null, lecturer: null};
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      universityId: new FormControl(null, [Validators.required]),
      lecturerId: new FormControl(null, [Validators.required])
    });
  }
}
