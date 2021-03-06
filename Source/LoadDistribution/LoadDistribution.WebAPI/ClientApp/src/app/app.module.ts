import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { MaterialModule } from './material.module';

import { AppComponent } from './app.component';
import { LanguageInterceptor } from './interceptors/language.interceptor';
import { CatchErrorInterceptor } from './interceptors/catch-error.interceptor';
import { ProjectListComponent } from './components/project/project-list/project-list.component';
import { ProjectComponent } from './components/project/project/project.component';
import { BaseComponent } from './components/common/base/base.component';
import { FormActionsComponent } from './components/common/form-actions/form-actions.component';
import { ProjectSelectComponent } from './components/project/project-select/project-select.component';
import { UniversityListComponent } from './components/university/university-list/university-list.component';
import { UniversityComponent } from './components/university/university/university.component';
import { ActivityListComponent } from './components/activity/activity-list/activity-list.component';
import { ActivityComponent } from './components/activity/activity/activity.component';
import { LecturerComponent } from './components/lecturer/lecturer/lecturer.component';
import { LecturerListComponent } from './components/lecturer/lecturer-list/lecturer-list.component';
import { DisciplineComponent } from './components/discipline/discipline/discipline.component';
import { DisciplineListComponent } from './components/discipline/discipline-list/discipline-list.component';
import { LocalizablePipe } from './pipes/localizable.pipe';
import { LogListComponent } from './components/log/log-list/log-list.component';
import { DialogComponent } from './components/common/dialog/dialog.component';
import { UniversityLecturerMapComponent } from './components/universityLecturerMap/university-lecturer-map/university-lecturer-map.component';
import { UniversityLecturerMapListComponent } from './components/universityLecturerMap/university-lecturer-map-list/university-lecturer-map-list.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { FirstSymbolPipe } from './pipes/firstSymbol.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ProjectListComponent,
    ProjectComponent,
    BaseComponent,
    FormActionsComponent,
    ProjectSelectComponent,
    UniversityListComponent,
    UniversityComponent,
    ActivityListComponent,
    ActivityComponent,
    LecturerComponent,
    LecturerListComponent,
    DisciplineComponent,
    DisciplineListComponent,
    LocalizablePipe,
    FirstSymbolPipe,
    LogListComponent,
    DialogComponent,
    UniversityLecturerMapComponent,
    UniversityLecturerMapListComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    MaterialModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LanguageInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CatchErrorInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}
