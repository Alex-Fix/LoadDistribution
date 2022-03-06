import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectDTO from "../models/dto/projectDTO";
import CollectionClient from './collectionClient.client';
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";

@Injectable({
    providedIn: 'root'
})
export default class ProjectClient extends CollectionClient<ProjectDTO> {
    constructor(
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super('project', client, snackBar, translateService);
    }
}