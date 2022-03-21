import { Component } from '@angular/core';
import LecturerDisciplineActivityMapClient from 'src/app/clients/lecturerDisciplineActivityMapClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import LecturerDisciplineActivityMapDTO from 'src/app/models/dto/models/lecturerDisciplineActivityMapDTO.model';

@Component({
  selector: 'app-lecturer-discipline-activity-map-list',
  templateUrl: './lecturer-discipline-activity-map-list.component.html',
  styleUrls: ['./lecturer-discipline-activity-map-list.component.scss']
})
export class LecturerDisciplineActivityMapListComponent extends TableComponent<LecturerDisciplineActivityMapDTO> {
  constructor(
    lecturerDisciplineActivityMapClient: LecturerDisciplineActivityMapClient,
    projectHanlder: ProjectHandler
  ) { 
    super(lecturerDisciplineActivityMapClient, ['lecturerId', 'lecturerLastName', 'lecturerFirstName', 'disciplineId', 'disciplineName', 'activityId', 'activityName', 'rate'], projectHanlder);
  }
}
