import { Injectable } from "@angular/core";
import { DependencyType } from "../models/enums/dependencyType.enum";
import ActivityCalculate from "../models/helpers/models/activityCalculation.model";
import CalculationResult from "../models/helpers/models/calculationResult.model";
import DisciplineCalculate from "../models/helpers/models/disciplineCalculation.model";

@Injectable({
    providedIn: 'root'
})
export default class CalculationService {
    calculate(discipline: DisciplineCalculate, activity: ActivityCalculate): CalculationResult {
        const totalHours = this._calculateTotalHours(discipline, activity);
        const comercialHours = this._calculateComercialHours(totalHours, discipline);
        const budgetHours = this._calculateBudgetHours(totalHours, discipline);

        return new CalculationResult(totalHours, comercialHours, budgetHours);
    }

    calculateAll(discipline: DisciplineCalculate, activities: ActivityCalculate[]): CalculationResult {
        const totalHours = activities.reduce((acc, a) => acc + this._calculateTotalHours(discipline, a), 0);
        const comercialHours = this._calculateComercialHours(totalHours, discipline);
        const budgetHours = this._calculateBudgetHours(totalHours, discipline);

        return new CalculationResult(totalHours, comercialHours, budgetHours);
    }

    private _calculateTotalHours(discipline: DisciplineCalculate, activity: ActivityCalculate): number {
        if (activity.value <= 0) {
            return 0;
        }

        switch(activity.dependencyType) {
            case DependencyType.absolute: 
                return activity.value;
            case DependencyType.groupCount:
                return discipline.groupCount * activity.value;
            case DependencyType.studentCount:
                return discipline.studentCount * activity.value;
            case DependencyType.subgroupCount:
                return  discipline.subgroupCount * activity.value;
            case DependencyType.threadCount:
                return  discipline.threadCount * activity.value;
            default:
                return 0;
        }
    }

    private _calculateComercialHours(totalHours: number, discipline: DisciplineCalculate): number {
        if (discipline.studentCount <= 0 || discipline.comercialStudentCount <= 0) {
            return 0;
        }

        return totalHours * discipline.comercialStudentCount / discipline.studentCount;
    }

    private _calculateBudgetHours(totalHours: number, discipline: DisciplineCalculate): number {
        if (discipline.studentCount <= 0 || discipline.budgetStudentCount <= 0) {
            return 0;
        }

        return totalHours * discipline.budgetStudentCount / discipline.studentCount;
    }
}