import ActivityDTO from "./activityDTO.model";
import BaseProjectRelatedDTO from "./baseProjectRelatedDTO.model";
import DisciplineDTO from "./disciplineDTO.model";

export default class DisciplineActivityMapDTO extends BaseProjectRelatedDTO {
    discipline: DisciplineDTO;
    activity: ActivityDTO;
}