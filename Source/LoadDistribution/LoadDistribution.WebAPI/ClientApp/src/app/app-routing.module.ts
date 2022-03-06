import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectListComponent } from './components/project/project-list/project-list.component';
import { ProjectComponent } from './components/project/project/project.component';

const routes: Routes = [
  { path: 'projects', component:  ProjectListComponent },
  { path: 'project', children: [ { path: '', component: ProjectComponent }, { path: ':id', component: ProjectComponent } ]},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
