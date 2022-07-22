import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BookingComponent } from './booking.component';
import { Bookingroutes } from '../routing/bookingroutes';


@NgModule({
  declarations: [ 
        BookingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(Bookingroutes)
  ],
  providers: [],
  bootstrap: [BookingComponent]
})
export class BookingModule
 { }