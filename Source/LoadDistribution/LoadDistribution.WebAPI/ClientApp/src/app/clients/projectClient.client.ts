import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectDTO from "../models/dto/models/projectDTO.model";
import CollectionClient from './collectionClient.client';
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ProjectHandler } from '../helpers/projectHandler.helper';
import InsertResult from '../models/helpers/models/insertResult.model';

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

    insert(entity: ProjectDTO): Observable<InsertResult> {
        return super.insert(entity).pipe(
            tap(result => this._projectHandler.insertedId = result.id)
        );
    }

    update(entity: ProjectDTO): Observable<void> {
        return super.update(entity).pipe(
            tap(_ => this._projectHandler.updatedId = entity.id)
        );
    }

    delete(id: number): Observable<void> {
        return super.delete(id).pipe(
            tap(_ => this._projectHandler.deletedId = id)
        );
    }
}