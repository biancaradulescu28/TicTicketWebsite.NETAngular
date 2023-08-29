import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private builder:FormBuilder, private toastr:ToastrService,
    private service:AuthService, private router:Router){

  }

  loginform=this.builder.group({
    email:this.builder.control('', Validators.compose([Validators.required, Validators.email])),
    password:this.builder.control('',Validators.compose([Validators.required, Validators.pattern('^.{6,}$')])),
  });

  continuelogin() {
    if (this.loginform.valid) {
      this.service.login(this.loginform.value).subscribe(
        () => {
          this.toastr.success('Logged in successfully!');
          if(this.loginform.value.email!=null){
            sessionStorage.setItem('email', this.loginform.value.email);
          }
          this.router.navigate(['']);
        },
        (error) => {
          if (error.status === 400) {
            this.toastr.error('Email or password incorrect!');
          }
        }
      );
    } else {
      this.toastr.warning('Please enter valid data');
    }
  }

}
