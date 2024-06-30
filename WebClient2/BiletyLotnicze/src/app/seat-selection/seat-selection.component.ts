import { Component, Input, Output, EventEmitter,OnInit } from '@angular/core';
import { Seat } from '../Models/seat.model';
import { TicketService } from '../Services/ticket.service';
import { AuthService } from '../Services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Class, TicketDTO } from '../Models/ticket.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.css']
})
export class SeatSelectionComponent implements OnInit {
  @Input() passengerName!: string;
  seats: any[] = [];
  selectedSeat: any = null;
  ticketForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private ticketService: TicketService
  ) {
    this.ticketForm = this.fb.group({
      seat: ['', Validators.required],
      class: [1, Validators.required], // Example class default value
      price: [100, Validators.required], // Example price default value
      flightId: [5, Validators.required], // Example flight ID default value
      airlineId: [2, Validators.required], // Example airline ID default value
    });
  }

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

  selectSeat(seat: any): void {
    if (seat.status === 'available') {
      this.selectedSeat = seat;
      this.ticketForm.patchValue({ seat: seat.id });
    }
  }

  buyTicket(): void {
    if (this.ticketForm.valid) {
      const ticketRequest: TicketDTO = {
        ...this.ticketForm.value,
        userId: 2 // Assuming a static userId or remove if not needed
      };
      this.ticketService.buyTicket(ticketRequest).subscribe(response => {
        console.log('Ticket purchase response:', response); // Log the response
          alert(response.message || 'Ticket purchased successfully');
      }, error => {
        alert('Error purchasing ticket: ' + error.message);
      });
    }
  }
}
