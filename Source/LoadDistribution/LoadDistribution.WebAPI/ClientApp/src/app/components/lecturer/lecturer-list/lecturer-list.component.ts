import { Component } from '@angular/core';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';

@Component({
  selector: 'app-lecturer-list',
  templateUrl: './lecturer-list.component.html',
  styleUrls: ['./lecturer-list.component.scss']
})
export class LecturerListComponent extends TableComponent<LecturerDTO> {
  constructor(
    lecturerClient: LecturerClient,
    projectHanlder: ProjectHandler
  ) { 
    super(lecturerClient, ['lastName', 'firstName', 'middleName'], projectHanlder);
  }
}
