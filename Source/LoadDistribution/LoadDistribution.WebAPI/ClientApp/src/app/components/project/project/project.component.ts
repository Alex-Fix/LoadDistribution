import { Component  } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import ProjectClient from 'src/app/clients/projectClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import ProjectDTO from 'src/app/models/dto/models/projectDTO.model';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent extends CUComponent<ProjectDTO> {
  constructor(
    private readonly _formBuilder: FormBuilder,
    projectClient: ProjectClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(projectClient, activatedRoute, router, '/projects');
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      title: new FormControl(null, [Validators.required]),
      description: new FormControl(null)
    });
  }
}
