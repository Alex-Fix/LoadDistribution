import { DependencyType } from "../../enums/dependencyType.enum";

export default class ActivityCalculation {
    dependencyType: DependencyType;
    value: number;

    constructor(dependencyType: DependencyType, value: number) {
        this.dependencyType = dependencyType;
        this.value = value;
    }
}