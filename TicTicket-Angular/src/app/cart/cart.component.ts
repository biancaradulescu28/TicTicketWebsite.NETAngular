import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CartService } from 'src/app/cart.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import {SingleEventService} from 'src/app/single-event.service'
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  ticketList$!:any[] | undefined;
  userResponse: any;
  email: string | null = sessionStorage.getItem('email');
  eventDetails: any;
  cartDetails: any;
  data:any;
  
  constructor(private builder:FormBuilder, private toastr:ToastrService,
    private service:CartService, private router:Router, private authservice: AuthService, 
    private singleservice: SingleEventService, private datePipe: DatePipe){

  }

  async ngOnInit(): Promise<void>  {
    try{
      this.userResponse = await this.authservice.isloggedIn(this.email);
      this.ticketList$ = await this.service.getCartListForUser(this.userResponse.id);
      //this.cartDetails = await this.singleservice.getCartDetails(this.userResponse.id);
  
    }catch(error) {
      console.error('Error fetching data', error);
      throw error;
    }
    
  }

  async getEventDetails(eventId:number): Promise<any>{
    try{
      this.eventDetails = await this.singleservice.getEventById(eventId).toPromise();
    }catch(error) {
      console.error('Error fetching data', error);
      throw error;
    }
  }

  formatDate(date: Date): string|null {
    return this.datePipe.transform(date, 'dd-MM-yyyy');
  }

  MakeOrder(){
    this.service.MakeOrder(this.userResponse.id,this.data);
  }
}
