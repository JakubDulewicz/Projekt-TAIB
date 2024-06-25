import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AirportComponent } from './airport/airport.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FlightService } from './Services/flight.service';
import { FlightComponent } from './flight/flight.component';
import { SeatSelectionComponent } from './seat-selection/seat-selection.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    AirportComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    FlightComponent,
    SeatSelectionComponent,
    AboutComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [FlightService],
  bootstrap: [AppComponent]
})
export class AppModule { }
