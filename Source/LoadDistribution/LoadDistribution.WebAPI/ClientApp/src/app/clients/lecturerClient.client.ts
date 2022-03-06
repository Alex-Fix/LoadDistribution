import LecturerDTO from "../models/dto/lecturerDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";

@Injectable({
    providedIn: 'root'
})
export default class LecturerClient extends ProjectRelatedCollectionClient<LecturerDTO> {
    constructor(
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super('lecturer', client, snackBar, translateService);
    }
}