import Client from "./client.client";
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";
import Paged from "../models/helpers/paged.model";
import BaseProjectRelatedDTO from "../models/dto/baseProjectRelatedDTO.model";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { ProjectHandler } from "../helpers/projectHandler.helper";

export default abstract class ProjectRelatedCollectionClient<TDTO extends BaseProjectRelatedDTO> extends Client<TDTO> {
    constructor(
        private readonly _projectHandler: ProjectHandler,
        controller: string,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(controller, client, snackBar, translateService);
    }

    getAll(): Observable<TDTO[]> {
        if(this._projectHandler.selected) {
            return this._client.get<TDTO[]>(this.url + `all?projectId=${this._projectHandler.selected?.id}`);
        }
        
        this._translateService.get([ 'common.snackBar.projectIsNotSelected', 'common.snackBar.close' ])
            .subscribe(literals => this._snackBar.open(literals['common.snackBar.projectIsNotSelected'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'errorSnack' }));

        return of([]);
    }

    getPaged(pageNumber: number = 0, pageSize: number = 0): Observable<Paged<TDTO>> {
        if(this._projectHandler.selected) {
            return this._client.get<Paged<TDTO>>(this.url + `paged?projectId=${this._projectHandler.selected?.id}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
        }
        
        this._translateService.get([ 'common.snackBar.projectIsNotSelected', 'common.snackBar.close' ])
            .subscribe(literals => this._snackBar.open(literals['common.snackBar.projectIsNotSelected'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'errorSnack' }));

        return of({
            pageCount: 0,
            pageSize: 0,
            pageNumber: 0,
            totalCount: 0,
            list: []
        });
    }
}