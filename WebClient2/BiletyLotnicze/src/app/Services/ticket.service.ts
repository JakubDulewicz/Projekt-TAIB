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
    return this.http.post(`https://localhost:7009/Ticket/BuyTicket`, ticketRequest);
  }
}