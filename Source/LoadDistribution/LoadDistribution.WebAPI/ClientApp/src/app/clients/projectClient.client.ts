import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectDTO from "../models/dto/projectDTO";
import CollectionClient from './collectionClient.client';
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ProjectHandler } from '../helpers/projectHandler.helper';

@Injectable({
    providedIn: 'root'
})
export default class ProjectClient extends CollectionClient<ProjectDTO> {
    constructor(
        private readonly _projectHandler: ProjectHandler,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super('project', client, snackBar, translateService);
    }

    insert(entity: ProjectDTO): Observable<ProjectDTO> {
        return super.insert(entity).pipe(
            tap(project => this._projectHandler.inserted = project)
        );
    }

    update(entity: ProjectDTO): Observable<ProjectDTO> {
        return super.update(entity).pipe(
            tap(project => this._projectHandler.updated = project)
        );
    }

    delete(id: number): Observable<ProjectDTO> {
        return super.delete(id).pipe(
            tap(project => this._projectHandler.deleted = project)
        );
    }
}