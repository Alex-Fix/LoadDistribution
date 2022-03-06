import UniversityDTO from "../models/dto/universityDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";

@Injectable({
    providedIn: 'root'
})
export default class UniversityClient extends ProjectRelatedCollectionClient<UniversityDTO> {
    constructor(
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super('university', client, snackBar, translateService);
    }
}