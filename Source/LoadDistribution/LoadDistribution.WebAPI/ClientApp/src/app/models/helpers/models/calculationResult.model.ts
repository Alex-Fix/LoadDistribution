export default class CalculationResult {
    totalHours: number;
    comercialHours: number;
    budgetHours: number;

    constructor(totalHours: number, comercialHours: number, budgetHours: number) {
        this.totalHours = totalHours;
        this.comercialHours = comercialHours;
        this.budgetHours = budgetHours;
    }
}