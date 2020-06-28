import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { SchoolsRoutingModule } from './schools-routing.module';
import { SchoolListComponent } from './school-list/school-list.component';
import { SchoolFormComponent } from './school-form/school-form.component';

@NgModule({
  declarations: [SchoolListComponent, SchoolFormComponent],
  imports: [
    CommonModule,
    SchoolsRoutingModule,
    ReactiveFormsModule
  ]
})
export class SchoolsModule { }
