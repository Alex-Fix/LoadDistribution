import LecturerDTO from "../models/dto/models/lecturerDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { ProjectHandler } from "../helpers/projectHandler.helper";

@Injectable({
    providedIn: 'root'
})
export default class LecturerClient extends ProjectRelatedCollectionClient<LecturerDTO> {
    constructor(
        projectHandler: ProjectHandler,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(projectHandler, 'lecturer', client, snackBar, translateService);
    }
}