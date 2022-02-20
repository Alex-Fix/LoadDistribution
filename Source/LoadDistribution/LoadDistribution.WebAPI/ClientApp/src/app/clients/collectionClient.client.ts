import Client from "./client.client";
import BaseDTO from "../models/dto/baseDTO.model";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import Paged from "../models/helpers/paged.model";

export default abstract class CollectionClient<TDTO extends BaseDTO> extends Client<TDTO> {
    constructor(
        controller: string,
        client: HttpClient
    ) {
        super(controller, client);
    }

    getAll(): Observable<TDTO[]> {
        return this._client.get<TDTO[]>(this.url + 'all');
    }

    getPaged(pageNumber: number, pageSize: number): Observable<Paged<TDTO>> {
        return this._client.get<Paged<TDTO>>(this.url + `paged?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    }
}