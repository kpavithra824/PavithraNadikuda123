import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { AirlineComponent } from './airline.component';
import { Airlineroutes } from '../routing/airlineroutes';
import { CommonModule } from '@angular/common';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { TokenInterceptorService } from '../services/token-interceptor.service';


@NgModule({
  declarations: [ 
        AirlineComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(Airlineroutes),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true }],
  bootstrap: [AirlineComponent]
})
export class AirlineModule
 { }
