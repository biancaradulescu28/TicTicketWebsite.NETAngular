import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SingleEventService } from '../single-event.service';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { TicketUser } from '../ticket-user.model';
import { DatePipe } from '@angular/common';
// import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-single-event',
  templateUrl: './single-event.component.html',
  styleUrls: ['./single-event.component.css']
})
export class SingleEventComponent {

  eventName: string | null = sessionStorage.getItem('eventName');
  eventDetails: any;
  ticketDetails: any;
  cartDetails: any;
  addressDetails: any;
  userResponse: any;
  data: any;
  ticketUser: TicketUser = {
    ticketsId: 0,
    usersId: 0,   
  };
  email: string | null = sessionStorage.getItem('email');

  ticketList$!:Observable<any[]>;

  constructor(private builder:FormBuilder, private toastr:ToastrService,
    private service:SingleEventService, private router:Router, private authservice: AuthService,
    private datePipe: DatePipe){

  }


  async ngOnInit(): Promise<void> {
    if (this.eventName) {
      try {
        this.eventDetails = await this.service.getEventByName(this.eventName).toPromise();
        const tickets = await this.service.getEventTickets(this.eventDetails.id).toPromise();
  
        if (tickets && tickets.length > 0) {
          this.ticketDetails = tickets[0];
        }

        this.userResponse = await this.authservice.isloggedIn(this.email);
        this.ticketUser.ticketsId = this.ticketDetails.id;
        this.ticketUser.usersId = this.userResponse.id;

        this.addressDetails = await this.service.getAddressById(this.eventDetails.addressId).toPromise();


      } catch (error) {
        console.error('Error fetching data', error);
      }
    }
  }



  async addToCart(data: any) {
    if(this.userResponse!=null && this.ticketDetails!=null){
      await this.service.addTicketUser(this.ticketDetails.id, this.userResponse.id,data).toPromise();
      this.cartDetails = await this.service.getCartDetails(this.userResponse.id).toPromise();
    }
  }

  ngAfterViewInit(): void {
    const buyButton = document.getElementById('buyTicketButton');
    if (buyButton) {
      buyButton.addEventListener('shown.bs.modal', () => {
        this.addToCart(this.ticketUser);
      });
    }
  }

  formatDate(date: Date): string|null {
    return this.datePipe.transform(date, 'dd-MM-yyyy');
  }

}
