import { Component } from '@angular/core';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import DisciplineDTO from 'src/app/models/dto/models/disciplineDTO.model';

@Component({
  selector: 'app-discipline-list',
  templateUrl: './discipline-list.component.html',
  styleUrls: ['./discipline-list.component.scss']
})
export class DisciplineListComponent extends TableComponent<DisciplineDTO> {
  constructor(
    disciplineClient: DisciplineClient,
    projectHanlder: ProjectHandler
  ) { 
    super(disciplineClient, ['term', 'educationLevel', 'educationForm', 'planIndex', 'speciality', 'groupAbbreviation', 'specialization', 'institute', 'course', 'studentCount', 'budgetStudentCount', 'comercialStudentCount', 'groupCount', 'subgroupCount', 'threadCount', 'name', 'type', 'universityId', 'universityName'], projectHanlder);
  }
}
