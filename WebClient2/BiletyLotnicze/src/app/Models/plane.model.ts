import { FlightDTO } from "./flight.model";
import { AirlineDTO } from "./airline.model";

export interface PlaneDTO {
    id: number;
    model: string;
    yearOfProduction: string;
    seatCount: number;
    hasPrivateCabins: boolean;
    flights: FlightDTO | null;
    airlines: AirlineDTO | null;
}