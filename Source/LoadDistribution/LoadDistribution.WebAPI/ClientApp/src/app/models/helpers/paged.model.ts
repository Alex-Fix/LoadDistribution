export default class Paged<TEntity> {
    pageNumber: number;
    pageSize: number;
    pageCount: number;
    totalCount: number;
    list: TEntity[];
}