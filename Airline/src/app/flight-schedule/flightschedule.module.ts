import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { FlightScheduleComponent } from './flight-schedule.component';
import {  FlightScheduleroutes } from '../routing/flightScheduleroutes';
import { CommonModule } from '@angular/common';
import { ListofFlightScheduleComponent } from './listofFlightSchedule.component';



@NgModule({
  declarations: [ 
        FlightScheduleComponent,ListofFlightScheduleComponent
        
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(FlightScheduleroutes)
  ],
  providers: [],
  bootstrap: [FlightScheduleComponent,ListofFlightScheduleComponent]
})
export class FlightScheduleModule
 { }
