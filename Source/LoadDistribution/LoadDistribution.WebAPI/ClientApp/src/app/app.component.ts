import { Component } from '@angular/core';
import { LanguageService } from 'src/app/services/language.service';
import ActivityClient from './clients/activityClient.client';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private readonly _languageService: LanguageService, private readonly _activityClient: ActivityClient
  ) {
      _languageService.setSavedOrDefault();
      _activityClient.getPaged(1, 30).subscribe(res => console.log(res));
  }
}
