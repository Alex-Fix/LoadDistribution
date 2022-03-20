import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { merge, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import ProjectClient from 'src/app/clients/projectClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import ProjectDTO from 'src/app/models/dto/models/projectDTO.model';

@Component({
  selector: 'app-project-select',
  templateUrl: './project-select.component.html',
  styleUrls: ['./project-select.component.scss']
})
export class ProjectSelectComponent implements OnInit {
  projects$: Observable<ProjectDTO[]> = this._projectClient.getAll();
  projectControl: FormControl = new FormControl();

  constructor(
    private readonly _projectClient: ProjectClient,
    private readonly _projectHandler: ProjectHandler
  ) { }

  ngOnInit(): void {
    this._loadData();
    this._initSubscriptions();
  }

  private _loadData(): void {
    this.projects$ = this._projectClient.getAll().pipe(
      tap(projects => this.projectControl.setValue(
        projects.find(p => p.id == this._projectHandler.selected?.id)
      ))
    );
  }

  private _initSubscriptions(): void {
    merge(
      this._projectHandler.insertedId$,
      this._projectHandler.updatedId$,
      this._projectHandler.deletedId$
    ).subscribe(id => id && this._loadData());
  }

  onSelectionChange(): void {
    this._projectHandler.selected = this.projectControl.value;
  }

  onOpenedChange(event: boolean): void {
    if(!event && !this.projectControl.value) {
      this._projectHandler.selected = null;
    }
  }
}
