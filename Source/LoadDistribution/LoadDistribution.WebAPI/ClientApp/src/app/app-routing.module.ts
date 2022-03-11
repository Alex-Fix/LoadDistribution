import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectListComponent } from './components/project/project-list/project-list.component';
import { ProjectComponent } from './components/project/project/project.component';
import { ProjectRelatedGuard } from './guards/project-related.guard';

const routes: Routes = [
  { path: 'projects', component:  ProjectListComponent },
  { path: 'project', children: [ { path: '', component: ProjectComponent }, { path: ':id', component: ProjectComponent } ]},
  { path: '**', redirectTo: "projects" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
