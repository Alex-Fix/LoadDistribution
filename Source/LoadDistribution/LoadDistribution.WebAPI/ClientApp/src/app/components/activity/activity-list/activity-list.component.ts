import { Component } from '@angular/core';
import ActivityClient from 'src/app/clients/activityClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import ActivityDTO from 'src/app/models/dto/activityDTO.model';
import { DependencyType } from 'src/app/models/enums/dependencyType.enum';
import Localizable from 'src/app/models/helpers/localizable.model';
import EnumService from 'src/app/services/enum.service';

@Component({
  selector: 'app-activity-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.scss']
})
export class ActivityListComponent extends TableComponent<ActivityDTO> {
  dependencyTypes: Localizable<number>[] = this._enumService.toLocalizables('dependencyType', DependencyType);

  constructor(
    private readonly _enumService: EnumService,
    activityClient: ActivityClient,
    projectHanlder: ProjectHandler
  ) { 
    super(activityClient, ['name', 'dependencyType'], projectHanlder);
  }
}
