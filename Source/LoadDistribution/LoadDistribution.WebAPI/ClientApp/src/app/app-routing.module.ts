import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectListComponent } from './components/project/project-list/project-list.component';
import { ProjectComponent } from './components/project/project/project.component';
import { UniversityListComponent } from './components/university/university-list/university-list.component';
import { UniversityComponent } from './components/university/university/university.component';
import { ProjectRelatedGuard } from './guards/project-related.guard';

const routes: Routes = [
  { path: 'projects', component:  ProjectListComponent },
  { path: 'project', children: [{path: '', component: ProjectComponent}, {path: ':id', component: ProjectComponent}]},
  { path: 'universities', component: UniversityListComponent, canActivate: [ProjectRelatedGuard] },
  { path: 'university', children: [{path: '', component: UniversityComponent}, {path: ':id', component: UniversityComponent}] , canActivate: [ProjectRelatedGuard]},
  { path: '**', redirectTo: "projects" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
