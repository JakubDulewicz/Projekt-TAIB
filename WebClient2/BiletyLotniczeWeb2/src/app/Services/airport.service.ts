import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AirportResponseDto } from '../models/airport-response.interface';

@Injectable({
  providedIn: 'root'
})
export class AirportServiceService {

  private apiUrl = "https://localhost:7009/api/Airport"

  constructor(private http: HttpClient) { }

  get(params: { page: number, count: number }): Observable<AirportResponseDto[]> {
    return this.http.get<AirportResponseDto[]>(this.apiUrl + "/" + params.page + "/" + params.count);
  }
}
