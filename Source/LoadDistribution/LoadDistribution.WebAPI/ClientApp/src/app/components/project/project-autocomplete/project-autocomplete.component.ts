import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { merge, Observable } from 'rxjs';
import { map, startWith, tap } from 'rxjs/operators';
import ProjectClient from 'src/app/clients/projectClient.client';
import { ProjectHandler } from 'src/app/helpers/projectHandler.helper';
import ProjectDTO from 'src/app/models/dto/projectDTO';

@Component({
  selector: 'app-project-autocomplete',
  templateUrl: './project-autocomplete.component.html',
  styleUrls: ['./project-autocomplete.component.scss']
})
export class ProjectAutocompleteComponent implements OnInit {
  projects: ProjectDTO[];
  filteredProjects$: Observable<ProjectDTO[]>;
  projectControl: FormControl = new FormControl();
  constructor(
    private readonly _projectClient: ProjectClient,
    private readonly _projectHandler: ProjectHandler
  ) { }

  ngOnInit(): void {
    this._loadData();
    this._initFilter();
    this._initSubscriptions();
  }

  private _loadData(): void {
    this._projectClient.getAll().subscribe(projects => {
      this.projects = projects;
      this.projectControl.setValue(
        projects.find(p => p.id == this._projectHandler.selected?.id)
      );
    });
  }

  private _initFilter(): void {
    this.filteredProjects$ = this.projectControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }

  private _filter(value: string | ProjectDTO): ProjectDTO[] {
    const lowerTitle: string = typeof value == 'string' ? value?.toLowerCase() : value?.title?.toLowerCase();
    return this.projects?.filter(project => project.title.toLowerCase().includes(lowerTitle)) ?? [];
  }

  private _initSubscriptions(): void {
    merge(
      this._projectHandler.inserted$,
      this._projectHandler.updated$,
      this._projectHandler.deleted$
    ).subscribe(project => project && this._loadData());
  }

  getTitle(project: ProjectDTO): string {
    return project?.title;
  }

  onOptionSelected(): void {
    this._projectHandler.selected = this.projectControl.value;
  }

  onClosed(): void {
    if(!this.projectControl.value) {
      this._projectHandler.selected = null;
    }
  }
}
