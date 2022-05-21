import { FormGroup } from "@angular/forms";
import IDTO from "../../dto/interfaces/iDTO.interface";

export default interface IPayloadMapper<TDTO extends IDTO> {
    (dto: TDTO | null, form: FormGroup): any;
}