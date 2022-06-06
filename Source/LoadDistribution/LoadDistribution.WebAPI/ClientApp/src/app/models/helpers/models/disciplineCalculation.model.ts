export default class DisciplineCalculation {
    studentCount: number;
    groupCount: number;
    subgroupCount: number;
    threadCount: number;
    comercialStudentCount: number;
    budgetStudentCount: number;

    constructor(
        studentCount: number, 
        groupCount: number, 
        subgroupCount: number, 
        threadCount: number,
        comercialStudentCount: number,
        budgetStudentCount: number) {
            this.studentCount = studentCount;
            this.groupCount = groupCount;
            this.subgroupCount = subgroupCount;
            this.threadCount = threadCount;
            this.comercialStudentCount = comercialStudentCount;
            this.budgetStudentCount = budgetStudentCount;
    }
}