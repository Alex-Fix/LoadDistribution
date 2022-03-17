import { Injectable } from "@angular/core";
import Localizable from "../models/helpers/localizable.model";
import { Enum } from "../models/helpers/enum.model";

@Injectable({
    providedIn: 'root'
})
export default class EnumService {
    toLocalizables(preffix: string, $enum: Enum): Localizable<number>[] {
        return Object
            .entries($enum)
            .filter(([key]) => !+key)
            .map(([key, value]) => ({
                literal: this.formatKey(preffix, key), 
                value: value as number
            }));
    }

    private formatKey(preffix: string, key: string): string {
        return `${preffix}.${key}`;
    }
}