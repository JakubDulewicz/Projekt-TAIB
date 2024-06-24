import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'http://localhost:7009/api/Auth'; // Zmień na odpowiedni adres URL

  constructor(private http: HttpClient) { }

  register(user: any): Observable<any> {
    return this.http.post(`http://localhost:7009/api/Auth/register`, user);
  }

  login(credentials: any): Observable<any> {
    return this.http.post(`http://localhost:7009/api/Auth/login`, credentials);
  }
}
