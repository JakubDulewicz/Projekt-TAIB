import { PlaneDTO } from "./plane.model";
import { TicketDTO } from "./ticket.model";


export interface AirlineDTO {
    id: number;
    name: string;
    country: string;
    logo: string;
    planes: PlaneDTO[];
    ticket: TicketDTO[];
}