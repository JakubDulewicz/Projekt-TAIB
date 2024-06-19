import { Component } from '@angular/core';
import { AirportResponseDto } from '../models/airport-response.interface';
import { AirportServiceService } from '../Services/airport.service';

@Component({
  selector: 'app-airport-dto',
  templateUrl: './airport-dto.component.html',
  styleUrl: './airport-dto.component.css'
})
export class AirportDtoComponent {
  public page: number = 0;
  public count: number = 10;
  public data: AirportResponseDto[] = [];

  constructor(private airportService: AirportServiceService) {
    this.loadData();
  }

  private loadData(): void {
    this.airportService.get({ page: this.page, count: this.count }).subscribe({
      next: (res) => {
        console.log('Response from API:', res); // Logowanie odpowiedzi
        this.data = res;
      },
      error: (err) => console.error('Error:', err),
      complete: () => console.log('Request complete')
    });
  }

  public onPaginationSubmit(): void {
    this.page += 1;
    this.loadData();
  }
}
