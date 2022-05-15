import { HttpClient } from "@angular/common/http";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TranslateService } from "@ngx-translate/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { environment } from "src/environments/environment";
import IDTO from "../models/dto/interfaces/iDTO.interface";
import BulkInsertResult from "../models/helpers/bulkInsertResult.model";
import InsertResult from "../models/helpers/insertResult.model";
import Paged from "../models/helpers/paged.model";

export default abstract class Client<TDTO extends IDTO> {
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

    insert(entity: TDTO): Observable<InsertResult> {
        return this._client.post<InsertResult>(this.url, entity).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyInserted', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyInserted'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'success-snack' }));
            })
        );
    }

    bulkInsert(entities: TDTO[]): Observable<BulkInsertResult> {
        return this._client.post<BulkInsertResult>(this.url + "bulk", entities).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyInserted', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyInserted'], literals['common.snackBar.close'], { duration: 3000, panelClass: 'success-snack' }));
            })
        );
    }

    update(entity: TDTO): Observable<void> {
        return this._client.put<void>(this.url, entity).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyUpdated', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyUpdated'], literals['common.snackBar.close'], {duration: 3000, panelClass: 'success-snack'}));
            })
        );
    }

    bulkUpdate(entities: TDTO): Observable<void> {
        return this._client.put<void>(this.url + 'bulk', entities).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyUpdated', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyUpdated'], literals['common.snackBar.close'], {duration: 3000, panelClass: 'success-snack'}));
            })
        );
    }

    delete(id: number): Observable<void> {
        return this._client.delete<void>(this.url + id).pipe(
            tap(() => {
                this._translateService.get([ 'common.snackBar.successfullyDeleted', 'common.snackBar.close' ])
                    .subscribe(literals => this._snackBar.open(literals['common.snackBar.successfullyDeleted'], literals['common.snackBar.close'], {duration: 3000, panelClass: 'success-snack' }));
            })
        );
    }

    abstract getAll(): Observable<TDTO[]>;
    abstract getPaged(pageNumber: number, pageSize: number): Observable<Paged<TDTO>>;
}