import DisciplineDTO from "../models/dto/disciplineDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";

@Injectable({
    providedIn: 'root'
})
export default class DisciplineClient extends ProjectRelatedCollectionClient<DisciplineDTO> {
    constructor(
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super('discipline', client, snackBar, translateService);
    }
}