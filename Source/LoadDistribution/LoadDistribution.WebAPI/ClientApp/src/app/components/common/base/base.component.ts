import { Component, Input } from '@angular/core';
import BaseDTO from 'src/app/models/dto/models/baseDTO.model';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.scss']
})
export class BaseComponent {  
  @Input() base: BaseDTO;
}
