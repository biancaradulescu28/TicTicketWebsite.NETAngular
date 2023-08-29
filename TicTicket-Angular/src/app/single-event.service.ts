import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SingleEventService {

  readonly APiUrl = "https://localhost:7212/api";

  constructor(private http:HttpClient) {

  }

  
}
