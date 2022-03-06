import ActivityDTO from "../models/dto/activityDTO.model";
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import ProjectRelatedCollectionClient from "./projectRelatedCollectionClient.client";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";

@Injectable({
    providedIn: 'root'
})
export default class ActivityClient extends ProjectRelatedCollectionClient<ActivityDTO> {
    constructor(
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super('activity', client, snackBar, translateService);
    }
}