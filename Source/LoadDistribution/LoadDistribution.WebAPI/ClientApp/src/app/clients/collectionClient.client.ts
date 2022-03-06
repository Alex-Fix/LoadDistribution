import Client from "./client.client";
import BaseDTO from "../models/dto/baseDTO.model";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import Paged from "../models/helpers/paged.model";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";

export default abstract class CollectionClient<TDTO extends BaseDTO> extends Client<TDTO> {
    constructor(
        controller: string,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(controller, client, snackBar, translateService);
    }

    getAll(): Observable<TDTO[]> {
        return this._client.get<TDTO[]>(this.url + 'all');
    }

    getPaged(pageNumber: number = 0, pageSize: number = 0): Observable<Paged<TDTO>> {
        return this._client.get<Paged<TDTO>>(this.url + `paged?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    }
}