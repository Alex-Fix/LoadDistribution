import Client from "./client.client";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import Paged from "../models/helpers/paged.model";
import BaseProjectRelatedDTO from "../models/dto/baseProjectRelatedDTO.model";

export default abstract class ProjectRelatedCollectionClient<TDTO extends BaseProjectRelatedDTO> extends Client<TDTO> {
    constructor(
        controller: string,
        client: HttpClient
    ) {
        super(controller, client);
    }

    getAll(projectId: number): Observable<TDTO[]> {
        return this._client.get<TDTO[]>(this.url + `all?projectId=${projectId}`);
    }

    getPaged(projectId: number, pageNumber: number, pageSize: number): Observable<Paged<TDTO>> {
        return this._client.get<Paged<TDTO>>(this.url + `paged?projectId=${projectId}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
    }
}