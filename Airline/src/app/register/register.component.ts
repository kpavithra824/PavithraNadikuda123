import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { admindata } from '../models/admindata';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'

})
export class RegisterComponent implements OnInit {

  constructor(private _auth:AuthService,private _router:Router) { }
  RegisterModel:admindata=new admindata();
  ngOnInit(): void {
  }
  Register()
  {
    this._auth.registerUser(this.RegisterModel).subscribe(res => {
      localStorage.setItem('token', res.token);
      this._router.navigate(['/dashboard']);
    }, res => console.log(res));

  }

}
