import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AirportComponent } from './airport/airport.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FlightComponent } from './flight/flight.component';
import { SeatSelectionComponent } from './seat-selection/seat-selection.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {path: 'airports', component:AirportComponent},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {path: 'flights', component: FlightComponent},
  {path: 'seat-selection', component: SeatSelectionComponent},
  { path: '**', redirectTo: 'flights' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
