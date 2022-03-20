import { LogType } from "../../enums/logType.enum";
import IDTO from "../interfaces/iDTO.interface";

export default class LogDTO implements IDTO {
    id: number;
    created: Date;
    message: string;
    details: string;
    type: LogType;
    exceptionType: string;
}