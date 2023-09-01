import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  readonly APiUrl = "https://localhost:7212/api";

  constructor(private http:HttpClient) {

  }

  async getCartListForUser(userId: number): Promise<any[] | undefined> {
    try {
      const response = await this.http.get<any[]>(this.APiUrl + `/TicketsUsers/${userId}/GetAllTicketsInCart`).toPromise();
      return response;
    } catch (error) {
      console.error('Error fetching cart list:', error);
      return undefined;
    }
  }

  MakeOrder(userId:number, data:any){
    return this.http.post(this.APiUrl + `Orders/${userId}/MakeOrder`, data)
  }
  



}
