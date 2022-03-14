import { Component } from '@angular/core';
import UniversityClient from 'src/app/clients/universityClient.client';
import TableComponent from 'src/app/helpers/tableComponent.helper';
import UniversityDTO from 'src/app/models/dto/universityDTO.model';

@Component({
  selector: 'app-university-list',
  templateUrl: './university-list.component.html',
  styleUrls: ['./university-list.component.scss']
})
export class UniversityListComponent extends TableComponent<UniversityDTO> {
  constructor(
    universityClient: UniversityClient
  ) { 
    super(universityClient, ['name']);
  }
}
