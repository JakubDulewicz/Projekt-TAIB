import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'http://localhost:7009/api/auth'; // Upewnij się, że URL jest poprawny

  constructor(private http: HttpClient) { }

  register(user: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/register`, user).pipe(
      catchError(this.handleError)
    );
  }

  login(credentials: any): Observable<any> {
    console.log('Sending login request:', credentials); // Logowanie dla debugowania
    return this.http.post(`${this.baseUrl}/login`, credentials).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message); // Logowanie błędów
    if (error.error instanceof ErrorEvent) {
      // Błąd po stronie klienta
      console.error('Client-side error:', error.error.message);
    } else {
      // Błąd po stronie serwera
      console.error(`Server-side error: ${error.status} ${error.message}`);
    }
    return throwError('Something went wrong; please try again later.');
  }
}
