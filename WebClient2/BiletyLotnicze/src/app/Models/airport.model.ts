import { PlaneDTO } from "./plane.model";

export interface AirportDTO {
    airportId: number;
    name: string;
    iATA_CODE: string;
    country: string;
    city: string;
    address: string;
    planeId: number | null;
    planes: PlaneDTO[];
}