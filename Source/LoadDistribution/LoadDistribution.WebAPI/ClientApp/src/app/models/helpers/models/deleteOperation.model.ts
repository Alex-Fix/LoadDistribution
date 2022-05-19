import { FormGroup } from "@angular/forms";
import Operation from "./operation.model";

export default class DeleteOperation extends Operation {
    constructor(
        readonly id: number,
        form: FormGroup
    ) {
        super(form);
    }
}