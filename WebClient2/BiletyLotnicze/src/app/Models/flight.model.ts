import { AirportDTO } from "./airport.model";
import { PlaneDTO } from "./plane.model";
import { TicketDTO } from "./ticket.model";

export enum Status {
    Active,
    Delayed,
    Cancelled,
    Departed,
    Arrived
}

export interface FlightDTO {
    flightId: number;
    name: string;
    destination: string;
    departure: string;
    arrival: string;
    status: Status;
    airportIdTo: number | null;
    airportIdFrom: number | null;
    planeId: number | null;
    airportFrom: AirportDTO;
    airportTo: AirportDTO;
    plane: PlaneDTO;
    tickets: TicketDTO[];
}