import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './events/events.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { SingleEventComponent } from './single-event/single-event.component';
import {CartComponent} from './cart/cart.component';


const routes: Routes = [
  {path:'events',component:EventsComponent},
  {path:'',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'event',component:SingleEventComponent},
  {path:'cart',component:CartComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
