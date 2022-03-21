import BaseProjectRelatedDTO from "./baseProjectRelatedDTO.model";
import LecturerDTO from "./lecturerDTO.model";
import UniversityDTO from "./universityDTO.model";

export default class UniversityLecturerMapDTO extends BaseProjectRelatedDTO {
    universityId: number;
    lecturerId: number;
    university: UniversityDTO | null;
    lecturer: LecturerDTO | null;
}