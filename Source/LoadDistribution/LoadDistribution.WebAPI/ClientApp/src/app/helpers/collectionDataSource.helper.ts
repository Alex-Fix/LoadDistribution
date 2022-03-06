import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { MatPaginator } from "@angular/material/paginator";
import { BehaviorSubject, Observable, of } from "rxjs";
import { catchError, finalize, map, tap } from "rxjs/operators";
import CollectionClient from "../clients/collectionClient.client";
import BaseDTO from "../models/dto/baseDTO.model";
import Paged from "../models/helpers/paged.model";

export default class CollectionDataSource<TDTO extends BaseDTO> implements DataSource<TDTO> {
    private readonly _pageSizeOptions: number[] = [10, 15, 20, 50, 100, 200, 500];
    private readonly _defaultPaged: Paged<TDTO> = { list: [], pageCount: 0, totalCount: 0, pageSize: 0, pageNumber: 0 };
    private readonly _pageSubject: BehaviorSubject<Paged<TDTO>> = new BehaviorSubject<Paged<TDTO>>(this._defaultPaged);
    private readonly _loadingSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    isLoading: Observable<boolean> = this._loadingSubject.asObservable();
    
    constructor(
        private readonly _collectionClient: CollectionClient<TDTO>
    ) {}

    connect(collectionViewer: CollectionViewer): Observable<TDTO[]> {
        return this._pageSubject.pipe(map(page => page.list));
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this._pageSubject.complete();
        this._loadingSubject.complete();
    }

    loadPage(pageNumber: number = 0, pageSize: number = 0): void {
        this._loadingSubject.next(true);

        this._collectionClient.getPaged(pageNumber, pageSize)
            .pipe(
                catchError(() => of(this._defaultPaged)),
                finalize(() => this._loadingSubject.next(false))
            ).subscribe(page => {
                this._pageSubject.next(page)
            });
    }

    addPaginator(paginator: MatPaginator): void {
        setTimeout(() => {
            this._pageSubject.pipe(
                tap(page => {
                    paginator.pageIndex = page.pageNumber;
                    paginator.pageSize = page.pageSize;
                    paginator.length = page.totalCount;
                  })
            ).subscribe();
            
            paginator.pageSizeOptions = this._pageSizeOptions;
            
            paginator.page.pipe(
                tap(() => this.loadPage(
                  paginator.pageIndex,
                  paginator.pageSize
                ))
            ).subscribe();
        });
    }
}