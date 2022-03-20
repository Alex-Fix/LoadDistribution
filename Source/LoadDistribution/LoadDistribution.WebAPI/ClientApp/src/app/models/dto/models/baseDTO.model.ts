import IDTO from "../interfaces/iDTO.interface";

export default class baseDTO implements IDTO {
    id: number;
    created: Date;
    updated: Date;
}