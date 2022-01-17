import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LocalizationConstants } from 'src/helpers/constants/localization-constants';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private readonly _translate: TranslateService) {
      _translate.setDefaultLang(LocalizationConstants.defaultLanguage);
  }
}
