import BaseProjectRelatedDTO from "./baseProjectRelatedDTO.model";
import DisciplineActivityMapDTO from "./disciplineActivityMapDTO.model";
import LecturerDTO from "./lecturerDTO.model";

export default class LecturerDisciplineActivityMapDTO extends BaseProjectRelatedDTO {
    rate: number;
    lecturer: LecturerDTO;
    disciplineActivityMap: DisciplineActivityMapDTO;
}