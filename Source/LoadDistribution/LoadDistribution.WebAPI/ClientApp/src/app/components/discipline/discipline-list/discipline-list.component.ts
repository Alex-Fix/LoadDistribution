import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component } from '@angular/core';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import DisciplineDTO from 'src/app/models/dto/models/disciplineDTO.model';

@Component({
  selector: 'app-discipline-list',
  templateUrl: './discipline-list.component.html',
  styleUrls: ['./discipline-list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class DisciplineListComponent extends TableComponent<DisciplineDTO> {
  expandedDiscipline: DisciplineDTO | null;

  constructor(
    disciplineClient: DisciplineClient,
    projectHanlder: ProjectHandler
  ) { 
    super(disciplineClient, ['term', 'educationForm', 'groupAbbreviation', 'institute', 'course', 'name', 'type', 'universityName'], projectHanlder);
  }

  onDisciplineRowClick(discipline: DisciplineDTO) {
    this.expandedDiscipline = this.expandedDiscipline == discipline ? null : discipline;
  }
}
