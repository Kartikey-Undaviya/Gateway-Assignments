import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { WebapiService } from './webapi.service';
import { CommonModule } from '@angular/common';  
import { FormsModule } from '@angular/forms'; 
import { ReactiveFormsModule } from '@angular/forms';
import { CompanyModule } from './company/company.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
   
    FormsModule,
  ],
  providers: [WebapiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
