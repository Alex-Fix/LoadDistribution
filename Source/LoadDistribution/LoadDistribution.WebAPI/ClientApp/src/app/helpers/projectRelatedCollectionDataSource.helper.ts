import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { MatPaginator } from "@angular/material/paginator";
import { BehaviorSubject, Observable, of } from "rxjs";
import { catchError, finalize, map, tap } from "rxjs/operators";
import ProjectRelatedCollectionClient from "../clients/projectRelatedCollectionClient.client";
import BaseProjectRelatedDTO from "../models/dto/baseProjectRelatedDTO.model";
import Paged from "../models/helpers/paged.model";

export default class ProjectRelatedCollectionDataSource<TDTO extends BaseProjectRelatedDTO> implements DataSource<TDTO> {
    private readonly _pageSizeOptions: number[] = [10, 15, 20, 50, 100, 200, 500];
    private readonly _defaultPaged: Paged<TDTO> = { list: [], pageCount: 0, totalCount: 0, pageSize: 0, pageNumber: 0 };
    private readonly _pageSubject: BehaviorSubject<Paged<TDTO>> = new BehaviorSubject<Paged<TDTO>>(this._defaultPaged);
    private readonly _loadingSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    
    isLoading: Observable<boolean> = this._loadingSubject.asObservable();
    
    constructor(
        private readonly _projectRelatedCollectionClient: ProjectRelatedCollectionClient<TDTO>
    ) {}

    connect(collectionViewer: CollectionViewer): Observable<TDTO[]> {
        return this._pageSubject.pipe(map(page => page.list));
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this._pageSubject.complete();
        this._loadingSubject.complete();
    }

    loadPage(projectId: number, pageNumber: number = 0, pageSize: number = 0): void {
        this._loadingSubject.next(true);
        
        this._projectRelatedCollectionClient.getPaged(projectId, pageNumber, pageSize)
            .pipe(
                catchError(() => of(this._defaultPaged)),
                finalize(() => this._loadingSubject.next(false))
            ).subscribe(page => {
                this._pageSubject.next(page);
            });
    }

    addPaginator(paginator: MatPaginator): void {
        setTimeout(() => {
            this._pageSubject.pipe(
                tap(page => setTimeout(() => {
                    paginator.pageIndex = page.pageNumber;
                    paginator.pageSize = page.pageSize;
                    paginator.length = page.totalCount;
                    }))
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