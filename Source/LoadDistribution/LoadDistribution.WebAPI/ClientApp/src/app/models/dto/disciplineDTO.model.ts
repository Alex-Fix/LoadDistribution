import BaseDTO from './baseDTO.model';

export default interface DisciplineDTO extends BaseDTO {
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
}