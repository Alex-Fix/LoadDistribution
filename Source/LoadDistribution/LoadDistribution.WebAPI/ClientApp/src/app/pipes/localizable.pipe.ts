import { Pipe, PipeTransform } from "@angular/core";
import Localizable from "../models/helpers/models/localizable.model";

@Pipe({
    name: 'localizable'
})
export class LocalizablePipe implements PipeTransform {
    transform<TValue>(value: TValue, localizables: Localizable<TValue>[]) {
        return localizables.find(l => l.value == value)?.literal ?? 'common.undefined';
    }
}
