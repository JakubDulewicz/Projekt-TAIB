import { Injectable } from '@angular/core';
import { HttpClient , HttpParams, HttpErrorResponse} from '@angular/common/http';
import { Observable ,throwError } from 'rxjs';
import { AirportDTO } from '../Models/airport.model';
import { FlightDTO } from '../Models/flight.model';
import { catchError } from 'rxjs/operators';

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

  searchFlights(from: string, to: string): Observable<any[]> {
    let params = new HttpParams();
    params = params.append('airportNameFrom', from);
    params = params.append('airportNameTo', to);
    //params = params.append('flightDate', date);

    return this.http.get<FlightDTO[]>(`http://localhost:7009/Flight/FindFlightByNameAndDate`, { params }).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return throwError('Something went wrong; please try again later.');
  }
}
