import { FormGroup } from "@angular/forms";
import IDTO from "../../dto/interfaces/iDTO.interface";
import DeleteOperation from "./deleteOperation.model";
import Operation from "./operation.model";

export default class UpdateOperation<TDTO extends IDTO> extends Operation {
    constructor(
        readonly dto: TDTO,
        form: FormGroup
    ) {
        super(form);
    }

    toDeleteOperation(): DeleteOperation {
        return new DeleteOperation(this.dto.id, this.form);
    }
}