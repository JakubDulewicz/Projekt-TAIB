import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { FlightDtoComponent } from '../app/flight-dto/flight-dto.component';
import { AirlineDtoComponent } from '../app/airline-dto/airline-dto.component';
import { AirportDtoComponent } from '../app/airport-dto/airport-dto.component';
import { TicketDtoComponent } from '../app/ticket-dto/ticket-dto.component';
import { PlaneDtoComponent } from '../app/plane-dto/plane-dto.component';
import { UserDtoComponent } from '../app/user-dto/user-dto.component';
import { AirportResponseComponent } from './airport-response/airport-response.component';


@NgModule({
  declarations: [
    AppComponent,
    FlightDtoComponent,
    AirlineDtoComponent,
    AirportDtoComponent,
    UserDtoComponent,
    TicketDtoComponent,
    PlaneDtoComponent,
    AirportResponseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
