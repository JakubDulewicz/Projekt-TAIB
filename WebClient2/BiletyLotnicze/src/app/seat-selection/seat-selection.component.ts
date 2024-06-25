import { Component, Input, OnInit } from '@angular/core';
import { Seat } from '../Models/seat.model';

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.css']
})
export class SeatSelectionComponent implements OnInit {
  @Input() passengerName!: string;
  seats: any[] = [];
  selectedSeat: any = null;

  constructor() { }

  ngOnInit(): void {
    this.initializeSeats();
  }

  initializeSeats(): void {
    for (let i = 0; i < 10; i++) {
      let row = [];
      for (let j = 0; j < 6; j++) {
        row.push({
          id: `${i}${j}`,
          status: (Math.random() > 0.5) ? 'occupied' : 'available'
        });
      }
      this.seats.push(row);
    }
  }

  selectSeat(seat: Seat): void {
    if (seat.status === 'available') {
      this.selectedSeat = seat;
    }
  }
}
