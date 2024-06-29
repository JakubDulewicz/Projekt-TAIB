import { Component, Input, Output, EventEmitter,OnInit } from '@angular/core';
import { Seat } from '../Models/seat.model';
import { TicketService } from '../Services/ticket.service';
import { AuthService } from '../Services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Class, TicketDTO } from '../Models/ticket.model';

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.css']
})
export class SeatSelectionComponent implements OnInit {
  @Input() passengerName!: string;
  seats: any[] = [];
  selectedSeat: any = null;

  constructor(private ticketService: TicketService, private authService: AuthService) { }

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

  buyTicket(): void {
    if (this.selectedSeat) {
      const userId = this.authService.getUserId();
      const ticketRequest = {
        seat: this.selectedSeat.id,
        class: 1, // Example class
        price: 100, // Example price
        userId: userId,
        flightId: 5, // Example flight ID
        airlineId: 2 // Example airline ID
      };
      this.ticketService.buyTicket(ticketRequest).subscribe(response => {
        alert('Ticket purchased successfully');
      }, error => {
        alert('Error purchasing ticket: ' + error.message);
      });
    }
  }
}
