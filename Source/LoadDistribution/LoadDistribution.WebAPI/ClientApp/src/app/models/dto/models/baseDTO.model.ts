import IDTO from "../interfaces/iDTO.interface";

export default class BaseDTO implements IDTO {
    id: number;
    created: Date;
    updated: Date;
}