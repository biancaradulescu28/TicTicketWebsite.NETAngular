import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CartService } from 'src/app/cart.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import {SingleEventService} from 'src/app/single-event.service';

@Component({
  selector: 'app-cart-list',
  templateUrl: './cart-list.component.html',
  styleUrls: ['./cart-list.component.css']
})
export class CartListComponent {

  ticketList$!:Observable<any[]> | undefined;
  userResponse: any;
  email: string | null = sessionStorage.getItem('email');
  eventDetails: any;
  

  constructor(private builder:FormBuilder, private toastr:ToastrService,
    private service:CartService, private router:Router, private authservice: AuthService, private singleservice: SingleEventService){

  }

  async ngOnInit(): Promise<void>  {
    this.userResponse = await this.authservice.isloggedIn(this.email).toPromise();
    this.ticketList$ = this.service.getCartListForUser(this.userResponse.id);
  }

  async getEventDetails(eventId:number): Promise<any>{
    this.eventDetails = await this.singleservice.getEventById(eventId).toPromise();
  }

  


}
