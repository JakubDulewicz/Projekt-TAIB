import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AirportDTO } from '../Models/airport.model';
import { FlightDTO } from '../Models/flight.model';

@Injectable({
  providedIn: 'root'
})
export class FlightService {
  private baseUrl = 'http://localhost:7009'; // Zmień na rzeczywisty adres API

  constructor(private http: HttpClient) { }

  getAllAirports(): Observable<AirportDTO[]> {
    return this.http.get<AirportDTO[]>(`https://localhost:7009/Airport/AllAirports`);
  }

  getAllFlights(): Observable<any> {
    return this.http.get<FlightDTO[]>('https://localhost:7009/Flight/AllFlights');
  }

  searchFlights(from: string, to: string, date: string): Observable<any> {
    const url = `https://localhost:7009/Flight/FindFlightByNameAndDate?from=${from}&to=${to}&date=${date}`;
    return this.http.get<any>(url);
  }
}
