import { FormGroup } from "@angular/forms";
import IDTO from "../../dto/interfaces/iDTO.interface";
import DeleteOperation from "./deleteOperation.model";
import Operation from "./operation.model";
import UpdateOperation from "./updateOperation.model";

export default class UndefinedOperation<TDTO extends IDTO> extends Operation {
    constructor(
        readonly dto: TDTO,
        form: FormGroup
    ) {
        super(form);
    }

    toUpdateOperation(): UpdateOperation<TDTO> {
        return new UpdateOperation<TDTO>(this.dto, this.form);
    }

    toDeleteOperation(): DeleteOperation {
        return new DeleteOperation(this.dto.id, this.form);
    }
}