import Client from "./client.client";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import Paged from "../models/helpers/paged.model";
import BaseProjectRelatedDTO from "../models/dto/baseProjectRelatedDTO.model";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";

export default abstract class ProjectRelatedCollectionClient<TDTO extends BaseProjectRelatedDTO> extends Client<TDTO> {
    constructor(
        controller: string,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(controller, client, snackBar, translateService);
    }

    getAll(projectId: number): Observable<TDTO[]> {
        return this._client.get<TDTO[]>(this.url + `all?projectId=${projectId}`);
    }

    getPaged(projectId: number, pageNumber: number = 0, pageSize: number = 0): Observable<Paged<TDTO>> {
        return this._client.get<Paged<TDTO>>(this.url + `paged?projectId=${projectId}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
    }
}