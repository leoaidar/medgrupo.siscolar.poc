import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: 'schools', loadChildren: () => import('./pages/schools/schools.module').then(m => m.SchoolsModule) },
  { path: 'schoolclasses', loadChildren: () => import('./pages/schoolclasses/schoolclasses.module' ).then(m => m.SchoolclassesModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
