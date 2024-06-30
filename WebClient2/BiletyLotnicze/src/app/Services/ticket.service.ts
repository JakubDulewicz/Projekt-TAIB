import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private apiUrl = 'https://localhost:7009/api/BuyTicket'; // URL API dla ticket controller

  constructor(private http: HttpClient) { }

  buyTicket(ticketRequest: any): Observable<any> {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post(`https://localhost:7009/Ticket/BuyTicket`, ticketRequest, httpOptions).pipe(
      catchError(this.handleError));
  }

  private handleError(error: any): Observable<never> {
    console.error('An error occurred', error);
    return throwError('Something bad happened; please try again later.');
  }
}