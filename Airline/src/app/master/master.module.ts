import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { MasterComponent } from './master.component';
import { Mainroutes } from '../routing/mainroutes';
import { AuthService } from '../services/auth.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { TokenInterceptorService } from '../services/token-interceptor.service';

@NgModule({
  declarations: [ 
         HomeComponent,
         MasterComponent,LoginComponent,RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(Mainroutes),
    HttpClientModule
  ],
  providers: [AuthService, { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true }],
  bootstrap: [MasterComponent]
})
export class MasterModule
 { }
