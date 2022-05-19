import { FormGroup } from "@angular/forms";
import Operation from "./operation.model";

export default class CreateOperation extends Operation {
    constructor(form: FormGroup) {
        super(form);
    }
}