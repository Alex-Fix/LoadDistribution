import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import ActivityClient from 'src/app/clients/activityClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import ActivityDTO from 'src/app/models/dto/activityDTO.model';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss']
})
export class ActivityComponent extends CUComponent<ActivityDTO> {
  constructor(
    private readonly _formBuilder: FormBuilder,
    activityClient: ActivityClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(activityClient, activatedRoute, router, '/activities');
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      name: new FormControl(null, [Validators.required])
    });
  }
}
