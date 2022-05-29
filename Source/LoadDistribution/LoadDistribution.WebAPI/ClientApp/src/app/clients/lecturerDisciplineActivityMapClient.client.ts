import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from "rxjs";
import { ProjectHandler } from "../helpers/projectHandler.helper";
import LecturerDisciplineActivityMapDTO from "../models/dto/models/lecturerDisciplineActivityMapDTO.model";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";

@Injectable({
    providedIn: 'root'
})
export default class LecturerDisciplineActivityMapClient extends ProjectRelatedCollectionClient<LecturerDisciplineActivityMapDTO> {
    constructor(
        projectHandler: ProjectHandler,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(projectHandler, 'lecturerDisciplineActivityMap', client, snackBar, translateService);
    }

    search(disciplineId: number | null = null): Observable<LecturerDisciplineActivityMapDTO[]> {
        return this._client.get<LecturerDisciplineActivityMapDTO[]>(this.url + `search?disciplineId=${disciplineId ?? ''}`);
    }
}