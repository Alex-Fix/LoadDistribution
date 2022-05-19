import { FormGroup } from "@angular/forms";
import IDTO from "../../dto/interfaces/iDTO.interface";

export default interface IFormInitializer<TDTO extends IDTO> {
    (dto: TDTO | null): FormGroup;
}