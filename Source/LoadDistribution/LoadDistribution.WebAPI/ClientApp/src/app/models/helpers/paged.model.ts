export default interface Paged<TEntity> {
    pageNumber: number;
    pageSize: number;
    pageCount: number;
    list: TEntity[];
}