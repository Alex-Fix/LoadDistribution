import { Component, Input } from '@angular/core';
import CUComponent from 'src/app/helpers/cuComponent.helper';
import BaseDTO from 'src/app/models/dto/models/baseDTO.model';

@Component({
  selector: 'app-form-actions',
  templateUrl: './form-actions.component.html',
  styleUrls: ['./form-actions.component.scss']
})
export class FormActionsComponent {
  @Input() component: CUComponent<BaseDTO>;
}
