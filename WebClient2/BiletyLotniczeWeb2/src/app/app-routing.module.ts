import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { PlaneDtoComponent } from './plane-dto/plane-dto.component';
import { AirlineDtoComponent } from './airline-dto/airline-dto.component';
import { AirportDtoComponent } from './airport-dto/airport-dto.component';
import { TicketDtoComponent } from './ticket-dto/ticket-dto.component';
import { UserDtoComponent } from './user-dto/user-dto.component';
import { FlightDtoComponent } from './flight-dto/flight-dto.component';


const routes: Routes = [
  {path: 'planes', component: PlaneDtoComponent},
  {path: 'airlanes', component: AirlineDtoComponent},
  {path: 'airports', component: AirportDtoComponent},
  {path: 'tickets', component: TicketDtoComponent},
  {path: 'user', component: UserDtoComponent},
  {path: 'flight', component: FlightDtoComponent},
  {path: '', redirectTo: '/flight', pathMatch: 'full'}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }