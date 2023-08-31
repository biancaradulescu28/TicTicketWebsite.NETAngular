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

  getCartDetails(userId: number){
    return this.http.get(this.APiUrl + `/Carts/${userId}/GetCartByUser`);
  }

  getCartListForUser(userId: number):Observable<any[]>{
    return this.http.get<any>(this.APiUrl + `/TicketsUsers/${userId}/GetAllTicketsInCart`);

  }


}
