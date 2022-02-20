import BaseProjectRelatedDTO from "./baseProjectRelatedDTO.model";

export default interface LecturerDTO extends BaseProjectRelatedDTO {
    firstName: string;
    middleName: string;
    lastName: string;
}