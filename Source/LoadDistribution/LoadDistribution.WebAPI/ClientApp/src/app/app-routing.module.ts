import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivityListComponent } from './components/activity/activity-list/activity-list.component';
import { ActivityComponent } from './components/activity/activity/activity.component';
import { DisciplineListComponent } from './components/discipline/discipline-list/discipline-list.component';
import { DisciplineComponent } from './components/discipline/discipline/discipline.component';
import { LecturerListComponent } from './components/lecturer/lecturer-list/lecturer-list.component';
import { LecturerComponent } from './components/lecturer/lecturer/lecturer.component';
import { LogListComponent } from './components/log/log-list/log-list.component';
import { ProjectListComponent } from './components/project/project-list/project-list.component';
import { ProjectComponent } from './components/project/project/project.component';
import { UniversityListComponent } from './components/university/university-list/university-list.component';
import { UniversityComponent } from './components/university/university/university.component';
import { UniversityLecturerMapListComponent } from './components/universityLecturerMap/university-lecturer-map-list/university-lecturer-map-list.component';
import { UniversityLecturerMapComponent } from './components/universityLecturerMap/university-lecturer-map/university-lecturer-map.component';
import { ProjectRelatedGuard } from './guards/project-related.guard';

const routes: Routes = [
  { path: 'projects', component:  ProjectListComponent },
  { path: 'project', children: [{path: '', component: ProjectComponent}, {path: ':id', component: ProjectComponent}]},
  { path: 'universities', component: UniversityListComponent, canActivate: [ProjectRelatedGuard] },
  { path: 'university', children: [{path: '', component: UniversityComponent}, {path: ':id', component: UniversityComponent}], canActivate: [ProjectRelatedGuard]},
  { path: 'activities', component: ActivityListComponent, canActivate: [ProjectRelatedGuard] },
  { path: 'activity', children: [{path: '', component: ActivityComponent}, {path: ':id', component: ActivityComponent}], canActivate: [ProjectRelatedGuard]},
  { path: 'lecturers', component: LecturerListComponent, canActivate: [ProjectRelatedGuard] },
  { path: 'lecturer', children: [{path: '', component: LecturerComponent}, {path: ':id', component: LecturerComponent}], canActivate: [ProjectRelatedGuard]},
  { path: 'disciplines', component: DisciplineListComponent, canActivate: [ProjectRelatedGuard] },
  { path: 'discipline', children: [{path: '', component: DisciplineComponent}, {path: ':id', component: DisciplineComponent}], canActivate: [ProjectRelatedGuard]},
  { path: 'universityLecturerMaps', component: UniversityLecturerMapListComponent, canActivate: [ProjectRelatedGuard]},
  { path: 'universityLecturerMap', children: [{path: '', component: UniversityLecturerMapComponent}, {path: ':id', component: UniversityLecturerMapComponent}], canActivate: [ProjectRelatedGuard]},
  { path: 'logs', component: LogListComponent },
  { path: '**', redirectTo: "projects" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
