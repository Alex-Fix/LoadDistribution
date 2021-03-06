import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { ProjectHandler } from "../helpers/projectHandler.helper";
import DisciplineActivityMapDTO from "../models/dto/models/disciplineActivityMapDTO.model";
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export default class DisciplineActivityMapClient extends ProjectRelatedCollectionClient<DisciplineActivityMapDTO> {
    constructor(
        projectHandler: ProjectHandler,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(projectHandler, 'disciplineActivityMap', client, snackBar, translateService);
    }

    search(disciplineId: number | null = null): Observable<DisciplineActivityMapDTO[]> {
        return this._client.get<DisciplineActivityMapDTO[]>(this.url + `search?disciplineId=${disciplineId ?? ''}`);
    }
}