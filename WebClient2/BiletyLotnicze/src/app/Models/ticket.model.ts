import { FlightDTO } from "./flight.model";
import { AirlineDTO } from "./airline.model";
import { UsersDTO } from "./user.model";

export enum Class {
    First,
    Bussines,
    Economic
}

export interface TicketDTO {
    ticketId: number;
    seat: string;
    class: Class;
    price: number;
    user: UsersDTO;
    flight: FlightDTO;
    airlines: AirlineDTO;
}