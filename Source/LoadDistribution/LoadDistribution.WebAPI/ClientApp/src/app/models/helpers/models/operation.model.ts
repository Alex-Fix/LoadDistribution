import { FormGroup } from "@angular/forms";

export default abstract class Operation {
    constructor (
        readonly form: FormGroup
    ) {
    }
}