import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';

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

    return this.http.post(`https://localhost:7009/api/Auth/login`, credentials, { headers, observe: "response" }).pipe(
      map((response: HttpResponse<any>) => {
        const token = response.headers.get('Authorization');
        return { token };
      })
    );
  }
}
