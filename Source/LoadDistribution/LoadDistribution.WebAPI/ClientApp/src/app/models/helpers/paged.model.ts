import BaseDTO from "../dto/baseDTO.model";

export default class Paged<TEntity extends BaseDTO> {
    pageNumber: number;
    pageSize: number;
    pageCount: number;
    totalCount: number;
    list: TEntity[];
}