import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { SchoolclassListComponent } from './schoolclass-list/schoolclass-list.component';
import { SchoolclassFormComponent } from './schoolclass-form/schoolclass-form.component';

const routes: Routes = [
  { path: '', component: SchoolclassListComponent },
  { path: 'new', component: SchoolclassFormComponent },
  { path: ':id/edit', component: SchoolclassFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchoolClassesRoutingModule { }
