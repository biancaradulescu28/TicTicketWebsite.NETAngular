import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './events/events.component';
import { ListEventsComponent } from './events/list-events/list-events.component';
import { EventService } from './event.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/material.module';
import { ToastrModule } from 'ngx-toastr';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { SingleEventComponent } from './single-event/single-event.component';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    ListEventsComponent,
    RegisterComponent,
    LoginComponent,
    SingleEventComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    ToastrModule.forRoot()
  ],
  providers: [EventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
