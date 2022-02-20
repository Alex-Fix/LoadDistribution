import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map, filter } from 'rxjs/operators';
import ProjectClient from 'src/app/clients/projectClient.client';
import ProjectDTO from 'src/app/models/dto/projectDTO';

@Component({
  selector: 'app-project-autocomplete',
  templateUrl: './project-autocomplete.component.html',
  styleUrls: ['./project-autocomplete.component.scss']
})
export class ProjectAutocompleteComponent implements OnInit {
  private _projects: ProjectDTO[];
  projectControl: FormControl;
  filteredProjects: Observable<ProjectDTO[]>;
  
  constructor(
    private readonly _projectClient: ProjectClient
  ) { 
    this.projectControl = new FormControl();
  }

  async ngOnInit(): Promise<void> {
    this._projectClient.getAll().subscribe(projects => this._projects = projects);
    this.filteredProjects = this.projectControl.valueChanges.pipe(
      startWith(''),
      map(title => this._projectsFilter(title))
    );
  }

  private _projectsFilter(title: string): ProjectDTO[] {
    const lowerTitle = title.toLocaleLowerCase();
    return this._projects?.filter(project => project.title.toLocaleLowerCase().includes(lowerTitle));
  }
}
