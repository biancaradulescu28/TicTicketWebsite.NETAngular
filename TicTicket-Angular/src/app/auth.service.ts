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

  async login(data: any): Promise<any> {
    try {
      const response = await this.http.post(this.APiUrl + '/Auth/Login', data).toPromise();
      return response;
    } catch (error) {
      console.error('Error during login:', error);
      throw error; // Aruncăm eroarea mai departe pentru a putea trata cazurile de eroare în componentă.
    }
  }

  async isloggedIn(email: any): Promise<any> {
  try {
    const response = await this.http.get(this.APiUrl + `/Auth/${email}/GetUserByEmail`).toPromise();
    return response;
  } catch (error) {
    console.error('Error during user retrieval:', error);
    throw error; // Aruncăm eroarea mai departe pentru a putea trata cazurile de eroare în componentă.
  }
}
  
}
