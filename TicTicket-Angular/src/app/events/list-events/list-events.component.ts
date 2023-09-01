import { DatePipe } from '@angular/common';
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

  constructor(private service:EventService, private datePipe: DatePipe){}

  ngOnInit(): void {
    this.eventList$ = this.service.getAllEventsList();
  }

  goToEventDetails(event: any) {
    sessionStorage.setItem('eventName', event.name);
    sessionStorage.setItem('eventId', event.id);
  }

  formatDate(date: Date): string|null {
    return this.datePipe.transform(date, 'dd-MM-yyyy');
  }

 
  

}
