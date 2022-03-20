import Client from "./client.client";
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import Paged from "../models/helpers/paged.model";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { ProjectHandler } from "../helpers/projectHandler.helper";
import { tap } from "rxjs/operators";
import IProjectRelatedDTO from "../models/dto/interfaces/iProjectRelatedDTO.interface";

export default abstract class ProjectRelatedCollectionClient<TDTO extends IProjectRelatedDTO> extends Client<TDTO> {
    constructor(
        private readonly _projectHandler: ProjectHandler,
        controller: string,
        client: HttpClient,
        snackBar: MatSnackBar,
        translateService: TranslateService
    ) {
        super(controller, client, snackBar, translateService);
    }

    insert(entity: TDTO): Observable<TDTO> {
        if(this._projectHandler.selected) {
            entity.projectId = this._projectHandler.selected.id;
            return this._client.post<TDTO>(this.url, entity).pipe(
                tap(() => {
                    this._translateService.get([ 'common.snackBar.successfullyInserted', 'common.snackBar.close' ])
                        .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyInserted'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'success-snack' }));
                })
            );
        }
        
        this._translateService.get([ 'common.snackBar.projectIsNotSelected', 'common.snackBar.close' ])
            .subscribe(literals => this._snackBar.open(literals['common.snackBar.projectIsNotSelected'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'errorSnack' }));

        return throwError(new Error());
    }

    getAll(): Observable<TDTO[]> {
        if(this._projectHandler.selected) {
            return this._client.get<TDTO[]>(this.url + `all?projectId=${this._projectHandler.selected?.id}`);
        }
        
        this._translateService.get([ 'common.snackBar.projectIsNotSelected', 'common.snackBar.close' ])
            .subscribe(literals => this._snackBar.open(literals['common.snackBar.projectIsNotSelected'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'errorSnack' }));

        return throwError(new Error());
    }

    getPaged(pageNumber: number = 0, pageSize: number = 0): Observable<Paged<TDTO>> {
        if(this._projectHandler.selected) {
            return this._client.get<Paged<TDTO>>(this.url + `paged?projectId=${this._projectHandler.selected?.id}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
        }
        
        this._translateService.get([ 'common.snackBar.projectIsNotSelected', 'common.snackBar.close' ])
            .subscribe(literals => this._snackBar.open(literals['common.snackBar.projectIsNotSelected'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'errorSnack' }));

        return throwError(new Error());
    }
}