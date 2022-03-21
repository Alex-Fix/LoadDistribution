import { Component } from '@angular/core';
import UniversityLecturerMapClient from 'src/app/clients/universityLecturerMapClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import UniversityLecturerMapDTO from 'src/app/models/dto/models/universityLecturerMapDTO.model';

@Component({
  selector: 'app-university-lecturer-map-list',
  templateUrl: './university-lecturer-map-list.component.html',
  styleUrls: ['./university-lecturer-map-list.component.scss']
})
export class UniversityLecturerMapListComponent extends TableComponent<UniversityLecturerMapDTO> {
  constructor(
    universityLecturerMapClient: UniversityLecturerMapClient,
    projectHanlder: ProjectHandler
  ) { 
    super(universityLecturerMapClient, ['universityId', 'universityName', 'lecturerId', 'lecturerLastName', 'lecturerFirstName'], projectHanlder);
  }
}
