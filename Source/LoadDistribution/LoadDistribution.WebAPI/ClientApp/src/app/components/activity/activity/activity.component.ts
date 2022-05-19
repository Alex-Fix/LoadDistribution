import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import ActivityClient from 'src/app/clients/activityClient.client';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import ActivityDTO from 'src/app/models/dto/models/activityDTO.model';
import { DependencyType } from 'src/app/models/enums/dependencyType.enum';
import Localizable from 'src/app/models/helpers/models/localizable.model';
import EnumService from 'src/app/services/enum.service';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss']
})
export class ActivityComponent extends CUComponent<ActivityDTO> {
  dependencyTypes: Localizable<number>[] = this._enumService.toLocalizables("dependencyType", DependencyType);

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _enumService: EnumService,
    activityClient: ActivityClient,
    activatedRoute: ActivatedRoute,
    router: Router
  ) {
    super(activityClient, activatedRoute, router, '/activities');
  }

  protected _initForm(): void {
    this.form = this._formBuilder.group({
      name: new FormControl(null, [Validators.required]),
      dependencyType: new FormControl(null, [Validators.required])
    });
  }
}
