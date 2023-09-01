import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DatePipe } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './events/events.component';
import { ListEventsComponent } from './events/list-events/list-events.component';
import { EventService } from './event.service';
import { AuthService } from './auth.service';
import { CartService } from './cart.service';
import { SingleEventService } from './single-event.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/material.module';
import { ToastrModule } from 'ngx-toastr';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { SingleEventComponent } from './single-event/single-event.component';
import { CartComponent } from './cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    ListEventsComponent,
    RegisterComponent,
    LoginComponent,
    SingleEventComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatIconModule,
    MatButtonModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    DatePipe,
    ToastrModule.forRoot()
  ],
  providers: [EventService, 
    AuthService,CartService,
    SingleEventService, DatePipe

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
