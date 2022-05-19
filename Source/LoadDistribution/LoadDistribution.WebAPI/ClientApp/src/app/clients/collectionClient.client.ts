import Client from "./client.client";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import IDTO from "../models/dto/interfaces/iDTO.interface";
import Paged from "../models/helpers/models/paged.model";

export default abstract class CollectionClient<TDTO extends IDTO> extends Client<TDTO> {
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

    getPaged(pageNumber: number, pageSize: number): Observable<Paged<TDTO>> {
        return this._client.get<Paged<TDTO>>(this.url + `paged?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    }
}