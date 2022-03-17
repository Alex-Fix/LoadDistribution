import { DependencyType } from '../enums/dependencyType.enum';
import BaseProjectRelatedDTO from './baseProjectRelatedDTO.model';

export default class ActivityDTO extends BaseProjectRelatedDTO {
    name: string;
    dependencyType: DependencyType;
}