import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';

@Component({
  selector: 'app-lecturer',
  templateUrl: './lecturer.component.html',
  styleUrls: ['./lecturer.component.scss']
})
export class LecturerComponent extends CUComponent<LecturerDTO> {
  constructor(
    private readonly _formBuilder: FormBuilder,
    lecturerClient: LecturerClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(lecturerClient, activatedRoute, router, '/lecturers');
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      lastName: new FormControl(null, [Validators.required]),
      firstName: new FormControl(null, [Validators.required]),
      middleName: new FormControl(null, [Validators.required])
    });
  }
}
