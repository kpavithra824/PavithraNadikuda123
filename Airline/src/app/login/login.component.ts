import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { admindata } from '../models/admindata';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
 
})
export class LoginComponent implements OnInit {

  constructor(private _auth:AuthService,private _router:Router) { }
  LoginModel:admindata=new admindata();

  ngOnInit(): void {
  }
  Login(){
    this._auth.loginUser(this.LoginModel).subscribe(res => {
      localStorage.setItem('token', res.token);
      this._router.navigate(['/dashboard']);
    }, res => console.log(res));
    //this._auth.loginUser(this.LoginModel).subscribe(res=>{console.log(res);},res=>console.log(res));
  }
 

}
