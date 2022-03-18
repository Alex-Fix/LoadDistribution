import { MatPaginatorIntl } from "@angular/material/paginator";
import { TranslateService } from "@ngx-translate/core";

export default class PaginatorI18n extends MatPaginatorIntl {
    constructor(
        private readonly _translate: TranslateService
    ) { 
        super();
        this._init();
    }
    
    private _init(): void {
        this._translate.get([
            'common.paginator.itemsPerLabel',
            'common.paginator.nextPageLabel',
            'common.paginator.previousPageLabel',
            'common.paginator.firstPageLabel',
            'common.paginator.lastPageLabel',
            'common.paginator.rangePageLabel1',
            'common.paginator.rangePageLabel2'
        ]).subscribe(literals => {
            this.itemsPerPageLabel = literals['common.paginator.itemsPerLabel'];
            this.nextPageLabel = literals['common.paginator.nextPageLabel'];
            this.previousPageLabel = literals['common.paginator.previousPageLabel'];
            this.firstPageLabel = literals['common.paginator.firstPageLabel'];
            this.lastPageLabel = literals['common.paginator.lastPageLabel'];
            this.getRangeLabel = (page: number, pageSize: number, length: number): string => {
                if(length == 0 || pageSize == 0) {
                    return literals['common.paginator.rangePageLabel1']
                        .replace('{{length}}', length);
                }

                const startIndex = page * pageSize;
                const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
             
                return literals['common.paginator.rangePageLabel2']
                    .replace('{{startIndex}}', startIndex + 1)
                    .replace('{{endIndex}}', endIndex)
                    .replace('{{length}}', length);
            };
        });
    }
}