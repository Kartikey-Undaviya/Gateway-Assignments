import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { AddComponent } from './add/add.component';
import { DetailsComponent } from './details/details.component';

import { IndexComponent } from './index/index.component';
import { Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { WebapiService } from '../webapi.service';
import { EditComponent } from './edit/edit.component';


const routes: Routes = [
  {path:'add', component:AddComponent}
];

@NgModule({
  declarations: [AddComponent, DetailsComponent, IndexComponent, EditComponent],
  imports: [
 
    CommonModule,
    FormsModule
    
  
  ],
  exports: [
    AddComponent,
    
    
      DetailsComponent, 
      IndexComponent,
    
     ],
     providers: [WebapiService],
})
export class CompanyModule { }
