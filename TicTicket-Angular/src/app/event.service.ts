import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  readonly APiUrl = "https://localhost:7212/api";

  constructor(private http:HttpClient) { }

  getAllEventsList():Observable<any[]>{
    return this.http.get<any>(this.APiUrl + '/Events/GetAllEvents');
  }

  getEventByName(name:string, data:any){
    return this.http.get(this.APiUrl + `/Events/${name}/GetEventByName`);
  }

}
