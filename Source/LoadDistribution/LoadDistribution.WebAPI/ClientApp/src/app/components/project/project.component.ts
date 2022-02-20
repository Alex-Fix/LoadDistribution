import { Component, OnInit } from '@angular/core';
import ProjectClient from 'src/app/clients/projectClient.client';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent {

  constructor(
    private readonly _projectClient: ProjectClient
  ) { }

  
}
