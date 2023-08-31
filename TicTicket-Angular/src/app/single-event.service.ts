import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SingleEventService {

  readonly APiUrl = "https://localhost:7212/api";

  constructor(private http:HttpClient) {

  }

  getEventByName(eventName: string){
    return this.http.get(this.APiUrl + `/Events/${eventName}/GetEventByName`);
  }

  getEventById(eventId: number): any|undefined{
    return this.http.get(this.APiUrl + `/Events/${eventId}/GetEventById`);
  }

  getEventTickets(eventId: any):Observable<any[]>{
    return this.http.get<any>(this.APiUrl + `/Tickets/${eventId}/GetTicketsByEvent`);
  }

  addTicketUser(ticketId: number, userId:number, data:any){
    return this.http.post(this.APiUrl + `/TicketsUsers/${userId}/${ticketId}/AddTicketUser`, data)
  }

  addTicketToCart(ticketId: number, userId:number, data:any){
    return this.http.put(this.APiUrl + `/TicketsUsers/${userId}/${ticketId}/StatusCart`, data)
  }

  


}
