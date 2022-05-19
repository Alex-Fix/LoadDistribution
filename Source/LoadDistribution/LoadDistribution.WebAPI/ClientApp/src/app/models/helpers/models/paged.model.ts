import IDTO from "../../dto/interfaces/iDTO.interface";

export default class Paged<TEntity extends IDTO> {
    pageNumber: number;
    pageSize: number;
    pageCount: number;
    totalCount: number;
    list: TEntity[];
}