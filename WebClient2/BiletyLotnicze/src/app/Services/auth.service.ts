import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:7009/api/Auth'; // Upewnij się, że URL jest poprawny

  constructor(private http: HttpClient) { }

  register(user: any): Observable<any> {
    return this.http.post(`https://localhost:7009/api/Auth/register`, user);
  }

  login(credentials: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post(`${this.baseUrl}/login`, credentials, { headers, observe: 'response' }).pipe(
      map((response: HttpResponse<any>) => {
        console.log('Response:', response); // Loguj całą odpowiedź
        const token = response.body?.token; // Zakładając, że token jest w ciele odpowiedzi
        if (token) {
          console.log('Token received:', token); // Loguj otrzymany token
          localStorage.setItem('token', token); // Zapisz token w localStorage
        } else {
          console.warn('Token is missing in the response body'); // Ostrzeżenie, jeśli brak tokena w ciele odpowiedzi
        }
        return { token };
      })
    );
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
  getUserId(): number | null {
    const token = this.getToken();
    if (token) {
      try {
        const decodedToken: any = jwtDecode(token);
        return decodedToken?.userId ?? null; // Assuming the token has a userId field
      } catch (error) {
        console.error('Error decoding token:', error);
        return null;
      }
    }
    return null;
  }

  logout(): void {
    localStorage.removeItem('token');
  }
  getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }
}
