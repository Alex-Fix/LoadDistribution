import BaseProjectRelatedDTO from './baseProjectRelatedDTO.model';
import UniversityDTO from './universityDTO.model';

export default class DisciplineDTO extends BaseProjectRelatedDTO {
    name: string;
    type: string;
    term: number;
    educationLevel: string;
    educationForm: string;
    planIndex: string;
    speciality: string;
    groupAbbreviation: string;
    specialization: string;
    institute: string;
    course: number;
    studentCount: number;
    budgetStudentCount: number;
    comercialStudentCount: number;
    groupCount: number;
    subgroupCount: number;
    threadCount: number;
    universityId: number;
    university: UniversityDTO | null;
} 