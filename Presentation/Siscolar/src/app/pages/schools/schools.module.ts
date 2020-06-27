import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SchoolsRoutingModule } from './schools-routing.module';
import { SchoolListComponent } from './school-list/school-list.component';


@NgModule({
  declarations: [SchoolListComponent],
  imports: [
    CommonModule,
    SchoolsRoutingModule
  ]
})
export class SchoolsModule { }
