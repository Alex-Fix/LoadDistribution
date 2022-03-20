import BaseProjectRelatedDTO from "./baseProjectRelatedDTO.model";
import LecturerDTO from "./lecturerDTO.model";
import UniversityDTO from "./universityDTO.model";

export default class UniversityLecturerMapDTO extends BaseProjectRelatedDTO {
    university: UniversityDTO;
    lecturer: LecturerDTO;
}