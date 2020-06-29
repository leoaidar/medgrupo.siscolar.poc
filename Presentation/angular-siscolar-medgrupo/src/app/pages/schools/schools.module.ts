import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {HttpClientModule} from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDatabase } from '../../in-memory-database';

import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';


import { SchoolsRoutingModule } from './schools-routing.module';
import { SchoolListComponent } from './school-list/school-list.component';
import { SchoolFormComponent } from './school-form/school-form.component';


@NgModule({
  declarations: [SchoolListComponent, SchoolFormComponent],
  imports: [
    CommonModule,  
    SharedModule,
    SchoolsRoutingModule,
    ReactiveFormsModule
  ]
})
export class SchoolsModule { }
