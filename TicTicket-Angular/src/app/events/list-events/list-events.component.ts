import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { EventService } from 'src/app/event.service';

@Component({
  selector: 'app-list-events',
  templateUrl: './list-events.component.html',
  styleUrls: ['./list-events.component.css']
})
export class ListEventsComponent implements OnInit{

  //display all events
  eventList$!:Observable<any[]>;

  constructor(private service:EventService){}

  ngOnInit(): void {
    this.eventList$ = this.service.getAllEventsList();
  }

  

}
