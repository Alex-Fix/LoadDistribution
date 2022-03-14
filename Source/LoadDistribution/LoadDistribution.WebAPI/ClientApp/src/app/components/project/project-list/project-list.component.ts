import { Component } from '@angular/core';
import ProjectClient from 'src/app/clients/projectClient.client';
import ProjectDTO from 'src/app/models/dto/projectDTO';
import TableComponent from 'src/app/helpers/tableComponent.helper';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent extends TableComponent<ProjectDTO> {
  constructor(
    projectClient: ProjectClient
  ) { 
    super(projectClient, ['title', 'description']);
  }
}
