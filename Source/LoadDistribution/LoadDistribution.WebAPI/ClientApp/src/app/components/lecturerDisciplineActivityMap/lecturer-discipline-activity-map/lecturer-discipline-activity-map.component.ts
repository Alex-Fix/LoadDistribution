import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import ActivityClient from 'src/app/clients/activityClient.client';
import DisciplineClient from 'src/app/clients/disciplineClient.client';
import LecturerClient from 'src/app/clients/lecturerClient.client';
import LecturerDisciplineActivityMapClient from 'src/app/clients/lecturerDisciplineActivityMapClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import ActivityDTO from 'src/app/models/dto/models/activityDTO.model';
import DisciplineDTO from 'src/app/models/dto/models/disciplineDTO.model';
import LecturerDisciplineActivityMapDTO from 'src/app/models/dto/models/lecturerDisciplineActivityMapDTO.model';
import LecturerDTO from 'src/app/models/dto/models/lecturerDTO.model';

@Component({
  selector: 'app-lecturer-discipline-activity-map',
  templateUrl: './lecturer-discipline-activity-map.component.html',
  styleUrls: ['./lecturer-discipline-activity-map.component.scss']
})
export class LecturerDisciplineActivityMapComponent extends CUComponent<LecturerDisciplineActivityMapDTO> {
  lecturers$: Observable<LecturerDTO[]> = this._lecturerClient.getAll();
  disciplines$: Observable<DisciplineDTO[]> = this._disciplineClient.getAll();
  activities$: Observable<ActivityDTO[]> = this._activityClient.getAll();

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _lecturerClient: LecturerClient,
    private readonly _disciplineClient: DisciplineClient,
    private readonly _activityClient: ActivityClient,
    lecturerDisciplineActivityMapClient: LecturerDisciplineActivityMapClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(lecturerDisciplineActivityMapClient, activatedRoute, router, '/lecturerDisciplineActivityMaps');
  }

  protected _payloadMapper(): any {
    return {...this.base, ...this.form.value, lecturer: null, discipline: null, activity: null};
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      lecturerId: new FormControl(null, [Validators.required]),
      disciplineId: new FormControl(null, [Validators.required]),
      activityId: new FormControl(null, [Validators.required]),
      rate: new FormControl(null, [Validators.required])
    });
  }
}
