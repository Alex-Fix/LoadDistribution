import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import ProjectClient from 'src/app/clients/projectClient.client';
import TableDataSource from 'src/app/helpers/tableDataSource.helper';
import ProjectDTO from 'src/app/models/dto/projectDTO';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import BaseDTO from 'src/app/models/dto/baseDTO.model';

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
