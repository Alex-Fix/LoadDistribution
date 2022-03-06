import { HttpClient } from "@angular/common/http";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { environment } from "src/environments/environment";
import BaseDTO from "../models/dto/baseDTO.model";
import Paged from "../models/helpers/paged.model";

export default abstract class Client<TDTO extends BaseDTO> {
    constructor(
        protected readonly _controller: string,
        protected readonly _client: HttpClient,
        protected readonly _snackBar: MatSnackBar,
        protected readonly _translateService: TranslateService
    ) {}

    protected get url(): string {
        return `${environment.apiUrl}/${this._controller}/`;
    }

    get(id: number): Observable<TDTO> {
        return this._client.get<TDTO>(this.url + id);
    }

    insert(entity: TDTO): Observable<TDTO> {
        return this._client.post<TDTO>(this.url, entity).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyInserted', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyInserted'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'success-snack' }));
            })
        );
    }

    update(entity: TDTO): Observable<TDTO> {
        return this._client.put<TDTO>(this.url, entity).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyUpdated', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyUpdated'], literals['common.snackBar.close'], {duration: 3000, panelClass: 'success-snack'}));
            })
        );
    }

    delete(id: number): Observable<TDTO> {
        return this._client.delete<TDTO>(this.url + id).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyDeleted', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyDeleted'], literals['common.snackBar.close'], {duration: 3000, panelClass: 'success-snack' }));
            })
        );
    }
}