import BaseProjectRelatedDTO from "./baseProjectRelatedDTO.model";

export default class DisciplineActivityMapDTO extends BaseProjectRelatedDTO {
    disciplineId: number;
    activityId: number;
    value: number;
}