import { Component } from '@angular/core';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isDrawerOpened: boolean = false;

  constructor(
    languageService: LanguageService
  ) {
      languageService.setSavedOrDefault();
  }

  onMenuButtonClick(): void {
    this.isDrawerOpened = !this.isDrawerOpened;
  }
}
