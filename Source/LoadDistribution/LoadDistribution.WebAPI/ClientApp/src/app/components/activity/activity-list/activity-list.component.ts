import { Component } from '@angular/core';
import ActivityClient from 'src/app/clients/activityClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import ActivityDTO from 'src/app/models/dto/activityDTO.model';

@Component({
  selector: 'app-activity-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.scss']
})
export class ActivityListComponent extends TableComponent<ActivityDTO> {
  constructor(
    activityClient: ActivityClient,
    projectHanlder: ProjectHandler
  ) { 
    super(activityClient, ['name'], projectHanlder);
  }
}
