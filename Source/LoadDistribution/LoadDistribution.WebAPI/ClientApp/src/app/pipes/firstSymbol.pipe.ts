import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'firstSymbol'
})
export class FirstSymbolPipe implements PipeTransform {
    transform(value: string) {
        return value?.slice(0, 1);
    }
}
