import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SchoolClassesRoutingModule } from './schoolclasses-routing.module';
import { SchoolclassListComponent } from './schoolclass-list/schoolclass-list.component';
import { SchoolclassFormComponent } from './schoolclass-form/schoolclass-form.component';


@NgModule({
  declarations: [SchoolclassListComponent, SchoolclassFormComponent],
  imports: [
    CommonModule,
    SchoolClassesRoutingModule,
    SchoolclassListComponent,
    SchoolclassFormComponent
  ]
})
export class SchoolclassesModule { }
