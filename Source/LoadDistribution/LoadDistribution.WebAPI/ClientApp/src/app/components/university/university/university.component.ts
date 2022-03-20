import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import UniversityClient from 'src/app/clients/universityClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';

@Component({
  selector: 'app-university',
  templateUrl: './university.component.html',
  styleUrls: ['./university.component.scss']
})
export class UniversityComponent extends CUComponent<UniversityDTO> {
  constructor(
    private readonly _formBuilder: FormBuilder,
    universityClient: UniversityClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(universityClient, activatedRoute, router, '/universities');
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      name: new FormControl(null, [Validators.required])
    });
  }
}
