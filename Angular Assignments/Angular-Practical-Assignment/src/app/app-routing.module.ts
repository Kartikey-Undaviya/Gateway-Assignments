import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddComponent } from './company/add/add.component';
import { DetailsComponent } from './company/details/details.component';
import { EditComponent } from './company/edit/edit.component';
import { IndexComponent } from './company/index/index.component';

const routes: Routes = [
  {path:'add', component:AddComponent},
  {path:'index', component:IndexComponent},
  {path:'details',component:DetailsComponent},
  {path:'edit',component:EditComponent},
  {path:'',component:IndexComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
