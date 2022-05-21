import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import UniversityClient from 'src/app/clients/universityClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import DisciplineDTO from 'src/app/models/dto/models/disciplineDTO.model';
import UniversityDTO from 'src/app/models/dto/models/universityDTO.model';

@Component({
  selector: 'app-discipline',
  templateUrl: './discipline.component.html',
  styleUrls: ['./discipline.component.scss']
})
export class DisciplineComponent extends CUComponent<DisciplineDTO> {
  universities$: Observable<UniversityDTO[]> = this._universityClient.getAll();

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _universityClient: UniversityClient,
    disciplineClient: DisciplineClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(disciplineClient, activatedRoute, router, '/disciplines');
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
      universityId: new FormControl(null, [Validators.required])
    });
  }
}
