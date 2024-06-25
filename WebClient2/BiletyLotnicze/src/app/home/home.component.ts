import { Component, OnInit } from '@angular/core';
import { FlightService } from '../Services/flight.service'; // Spójny import
import { AirportService } from '../Services/airport.service';
import { FlightDTO } from '../Models/flight.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  flights: any[] = [];
  from: string = '';
  to: string = '';
  date: string = '';
  airports: any[] = [];
  page: number = 1; // Current page number
  pageSize: number = 10; // Items per page
  totalPages: number = 0;

  constructor(private flightService: FlightService, private airportService: AirportService, private router: Router) { }

  ngOnInit(): void {
    this.loadAirports();
    this.loadFlights();
    
  }

  loadAirports(): void {
    this.airportService.getAllAirports().subscribe(
      (data) => {
        this.airports = data;
      },
      (error) => console.error('Error fetching airports', error)
    );
  }

  loadFlights(): void {
    this.flightService.getAllFlights().subscribe(
      (data) => {
        this.flights = data;
      },
      error => {
        console.error('Error loading flights:', error); // Debug
      }
    );
  }

  filterFlights(): void {
    console.log('Filtering flights with parameters:', { from: this.from, to: this.to }); 
    this.flightService.searchFlights(this.from, this.to).subscribe(
      (data) => {
        this.flights = data;
        console.log('Flights received:', data); // Debugging log
      },
      error => {
        console.error('Error filtering flights:', error); // Debug
      }
    );
  }

  getAirportNameById(id: number): string {
    const airport = this.airports.find(airport => airport.id === id);
    return airport ? `${airport.name}, ${airport.country}` : 'Unknown Airport';
  }
  buyTicket(flight: FlightDTO): void {
    this.router.navigate(['/seat-selection'], { queryParams: { passengerName: 'Jan Nowak', flightId: flight.flightId } });//imię przykładowe
  }
}