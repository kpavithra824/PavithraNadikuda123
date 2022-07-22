import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router, RouterLink, Routes } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _registerUrl: string = "https://localhost:44304/api/1.0/flight/admin";
  private _loginUrl: string = "https://localhost:44304/api/1.0/flight/admin/login";

  constructor(private http: HttpClient, private _router: Router) {

  }
  loginUser(user: any) {
    return this.http.post<any>(this._loginUrl, user);
  }
  registerUser(user: any) {
    return this.http.post<any>(this._registerUrl, user);
  }
  logoutUser() {
    localStorage.removeItem('token');
  }
  loggedIn() {
    return !!localStorage.getItem('token');
  }
  getToken() {
    return localStorage.getItem('token');
  }
}

