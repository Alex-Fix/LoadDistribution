import ActivityDTO from "./activityDTO.model";
import BaseProjectRelatedDTO from "./baseProjectRelatedDTO.model";
import DisciplineDTO from "./disciplineDTO.model";
import LecturerDTO from "./lecturerDTO.model";

export default class LecturerDisciplineActivityMapDTO extends BaseProjectRelatedDTO {
    lecturerId: number;
    disciplineId: number;
    activityId: number;
    rate: number;
    discipline: DisciplineDTO | null;
    lecturer: LecturerDTO | null;
    activity: ActivityDTO | null;
}