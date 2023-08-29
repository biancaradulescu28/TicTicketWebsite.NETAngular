import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SingleEventService } from '../single-event.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-single-event',
  templateUrl: './single-event.component.html',
  styleUrls: ['./single-event.component.css']
})
export class SingleEventComponent {

  constructor(private builder:FormBuilder, private toastr:ToastrService,
    private service:SingleEventService, private router:Router){

  }

  

}
