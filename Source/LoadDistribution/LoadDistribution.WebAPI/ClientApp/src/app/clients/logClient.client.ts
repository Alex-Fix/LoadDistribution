import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import LogDTO from "../models/dto/models/logDTO.model";
import CollectionClient from "./collectionClient.client";

@Injectable({
    providedIn: 'root'
})
export default class LogClient extends CollectionClient<LogDTO> {
    constructor(
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super('log', client, snackBar, translateService);
    }
}