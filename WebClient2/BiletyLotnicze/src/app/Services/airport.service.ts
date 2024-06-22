import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AirportDTO } from '../Models/airport.model';

@Injectable({
  providedIn: 'root'
})
export class AirportService {

  private apiUrl = 'https://localhost:7009/Airport'; // Zmień na właściwy URL Twojego backendu

  constructor(private http: HttpClient) { }

  getAllAirports(): Observable<AirportDTO[]> {
    return this.http.get<AirportDTO[]>(`${this.apiUrl}/AllAirports`);
  }
}
