import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import ProjectClient from 'src/app/clients/projectClient.client';
import BaseDTO from 'src/app/models/dto/baseDTO.model';
import { ComponentMode } from 'src/app/models/helpers/componentMode.model';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent implements OnInit {
  componentModes = ComponentMode;
  componentMode: ComponentMode = ComponentMode.undefined;
  base: BaseDTO;
  projectForm: FormGroup;

  constructor(
    private readonly _projectClient: ProjectClient,
    private readonly _formBuilder: FormBuilder,
    private readonly _activeRoute: ActivatedRoute,
    private readonly _router: Router
  ) { }

  ngOnInit(): void {
    this._activeRoute.params.subscribe(params => this._tryLoadData(params.id));
    this._initProjectForm();
  }

  private _tryLoadData(id: number): void {
    this.componentMode = id ? ComponentMode.edit : ComponentMode.create;

    if(id){
      this._projectClient.get(id).subscribe(project => {
        this.base = project;
        this.projectForm.patchValue(project);
      });
    }
  }

  private _initProjectForm(): void {
    this.projectForm = this._formBuilder.group({
      title: new FormControl(null, [Validators.required]),
      description: new FormControl(null)
    });
  }

  onCreateButtonClick(): void {
    this._projectClient.insert(this.projectForm.value).subscribe(() => this._initProjectForm());
  }

  onCreateAndReturnButtonClick(): void {
    this._projectClient.insert(this.projectForm.value).subscribe(() => this._router.navigateByUrl('/projects'));
  }

  onUpdateButtonClick(): void {
    const updatedProject = {...this.base, ...this.projectForm.value};
    this._projectClient.update(updatedProject).subscribe(project => {
      this.base = project;
      this.projectForm.patchValue(project);
    });
  }

  onUpdateAndReturnButtonClick(): void {
    const updatedProject = {...this.base, ...this.projectForm.value};
    this._projectClient.update(updatedProject).subscribe(() => 
      this._router.navigateByUrl('/projects')
    );
  }
}
