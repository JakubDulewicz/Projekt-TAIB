import { TicketDTO } from "./ticket.model";

export enum Roles {
    Admin,
    Client,
    Guest,
    Employee
}

export interface UsersDTO {
    userId: number;
    name: string;
    pesel: string;
    email: string;
    password: string;
    date: string;
    phone: string;
    roles: Roles;
    tickets: TicketDTO[];
}