import { Component, OnInit } from '@angular/core';
import { LecturerService } from 'src/app/services/lecturer.service';

@Component({
  selector: 'app-lecturers',
  templateUrl: './lecturers.component.html',
  styleUrls: ['./lecturers.component.scss']
})
export class LecturersComponent implements OnInit {

  constructor(
    private readonly _lecturerService: LecturerService
  ) { 
    _lecturerService.get().subscribe();
  }

  ngOnInit(): void {
  }

}
