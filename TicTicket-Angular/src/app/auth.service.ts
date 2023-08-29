import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  readonly APiUrl = "https://localhost:7212/api";

  constructor(private http:HttpClient) {

  }

  register(data:any){
    return this.http.post(this.APiUrl + '/Auth/Register', data);
  }

  login(data:any){
    return this.http.post(this.APiUrl + '/Auth/Login', data);
  }

  loggedInUserEmail(){
    return sessionStorage.getItem('email')?.toString;
  }

  isloggedIn(data:any){
    var email = this.loggedInUserEmail;
    return this.http.get(this.APiUrl + `/Auth/${email}/GetUserByEmail`);
  }
  
}
