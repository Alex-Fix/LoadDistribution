import BaseDTO from './baseDTO.model';

export default interface ProjectDTO extends BaseDTO {
    title: string;
    description: string;
}