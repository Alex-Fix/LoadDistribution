import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import DisciplineDTO from 'src/app/models/dto/disciplineDTO.model';

@Component({
  selector: 'app-discipline',
  templateUrl: './discipline.component.html',
  styleUrls: ['./discipline.component.scss']
})
export class DisciplineComponent extends CUComponent<DisciplineDTO> {
  constructor(
    private readonly _formBuilder: FormBuilder,
    disciplineClient: DisciplineClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(disciplineClient, activatedRoute, router, '/disciplines');
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      name: new FormControl(null, [Validators.required]),
      type: new FormControl(null),
      term: new FormControl(null, [Validators.required]),
      educationLevel: new FormControl(null, ),
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
      threadCount: new FormControl(null, [Validators.required])
    });
  }
}
