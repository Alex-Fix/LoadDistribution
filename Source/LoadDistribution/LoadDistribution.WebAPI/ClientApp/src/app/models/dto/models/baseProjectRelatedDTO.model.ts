import IProjectRelatedDTO from "../interfaces/iProjectRelatedDTO.interface";
import BaseDTO from "./baseDTO.model";

export default class BaseProjectRelatedDTO extends BaseDTO implements IProjectRelatedDTO {
    projectId: number;
}