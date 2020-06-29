import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';

import { SchoolclassesRoutingModule } from './schoolclasses-routing.module';
import { SchoolclassListComponent } from './schoolclass-list/schoolclass-list.component';
import { SchoolclassFormComponent } from './schoolclass-form/schoolclass-form.component';

// import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
// import { InMemoryDatabase } from '../../in-memory-database';

@NgModule({
  declarations: [SchoolclassListComponent, SchoolclassFormComponent],
  imports: [
    CommonModule,
    SharedModule,
    SchoolclassesRoutingModule,
    ReactiveFormsModule
    // HttpClientInMemoryWebApiModule.forRoot(InMemoryDatabase)
  ]
})
export class SchoolclassesModule { }

