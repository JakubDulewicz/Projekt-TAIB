import { Component } from '@angular/core';
import { AirportDTO } from '../Models/airport.model';
import { AirportService } from '../Services/airport.service';

@Component({
  selector: 'app-airport-list',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.css']
})
export class AirportComponent {
  airports: AirportDTO[] = [];
  paginatedAirports: AirportDTO[] = [];
  page: number = 1; // Current page number
  pageSize: number = 10; // Items per page
  totalPages: number = 0;

  constructor(private airportService: AirportService) { }

  ngOnInit(): void {
    this.airportService.getAllAirports().subscribe(
      (data) => {
        this.airports = data;
        this.totalPages = Math.ceil(this.airports.length / this.pageSize);
        this.updatePaginatedAirports();
      },
      (error) => console.error('Error fetching airports', error)
    );
  }

  updatePaginatedAirports(): void {
    const startIndex = (this.page - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.paginatedAirports = this.airports.slice(startIndex, endIndex);
  }

  goToPage(page: number): void {
    this.page = page;
    this.updatePaginatedAirports();
  }

  previousPage(): void {
    if (this.page > 1) {
      this.page--;
      this.updatePaginatedAirports();
    }
  }

  nextPage(): void {
    if (this.page < this.totalPages) {
      this.page++;
      this.updatePaginatedAirports();
    }
  }
}
