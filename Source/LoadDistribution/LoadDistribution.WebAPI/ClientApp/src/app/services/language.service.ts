import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private readonly _storageKey: string = 'LanguageService.SavedLanguageCode';

  private readonly _accepted: string[] = [ 'uk-UA' ];
  private readonly _default: string = this._accepted[0];

  constructor(
    private readonly _translateService: TranslateService
  ) { }

  setSavedOrDefault(): void {
    const languageCode: string = this.getSavedOrDefault();

    localStorage.setItem(this._storageKey, languageCode);
    this._translateService.setDefaultLang(languageCode);
  }

  getSavedOrDefault(): string {
    let languageCode: string = localStorage.getItem(this._storageKey) ?? '';

    if(!this._accepted.some(al => al === languageCode)) {
      languageCode = this._default;
    }

    return languageCode;
  }
}
