import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from "rxjs";
import { ProjectHandler } from "../helpers/projectHandler.helper";
import UniversityLecturerMapDTO from "../models/dto/models/universityLecturerMapDTO.model";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";

@Injectable({
    providedIn: 'root'
})
export default class UniversityLecturerMapClient extends ProjectRelatedCollectionClient<UniversityLecturerMapDTO> {
    constructor(
        projectHandler: ProjectHandler,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(projectHandler, 'universityLecturerMap', client, snackBar, translateService);
    }

    search(lecturerId: number | null = null): Observable<UniversityLecturerMapDTO[]> {
        return this._client.get<UniversityLecturerMapDTO[]>(this.url + `search?lecturerId=${lecturerId ?? ''}`);
    }
}