import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  constructor(private builder:FormBuilder, private toastr:ToastrService,
    private service:AuthService, private router:Router){

  }

  registerform=this.builder.group({
    firstName:this.builder.control('',Validators.required),
    lastName:this.builder.control('',Validators.required),
    email:this.builder.control('', Validators.compose([Validators.required, Validators.email])),
    age:this.builder.control('',Validators.required),
    password:this.builder.control('',Validators.compose([Validators.required, Validators.pattern('^.{6,}$')])),
  });

  registration(){
    if(this.registerform.valid){
      this.service.register(this.registerform.value).subscribe(res => {
        this.toastr.success('Registered successfully!');
        this.router.navigate(['login']);
      });
    }
    else{
      this.toastr.warning('Please enter valid data');
    }
  }

  goToEvents() {
    if(this.registerform.valid){
      this.router.navigate(['/login']); 
    }
  }



}
