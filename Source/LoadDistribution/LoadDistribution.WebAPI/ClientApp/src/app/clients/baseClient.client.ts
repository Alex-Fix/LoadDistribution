import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import BaseDTO from "../models/dto/baseDTO.model";
import Paged from "../models/helpers/paged.model";

export default abstract class BaseClient<TDTO extends BaseDTO> {
    constructor(
        protected readonly _controller: string,
        protected readonly _client: HttpClient
    ) {}

    protected get url(): string {
        return `${environment.apiUrl}/${this._controller}/`;
    }

    getAll(): Observable<TDTO[]> {
        return this._client.get<TDTO[]>(this.url);
    }

    get(id: number): Observable<TDTO> {
        return this._client.get<TDTO>(this.url + id);
    }

    getPaged(pageNumber: number, pageSize: number): Observable<Paged<TDTO>> {
        return this._client.get<Paged<TDTO>>(this.url + `paged?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    }

    insert(entity: TDTO): Observable<TDTO> {
        return this._client.post<TDTO>(this.url, entity);
    }

    update(entity: TDTO): Observable<TDTO> {
        return this._client.put<TDTO>(this.url, entity);
    }

    delete(id: number): Observable<TDTO> {
        return this._client.delete<TDTO>(this.url + id);
    }
}