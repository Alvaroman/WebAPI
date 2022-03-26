import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Parkinglot } from "../model/parkinglot";
import { HttpService } from "@core/services/http.service";

@Injectable()
export class ParkinglotService {
  constructor(protected http: HttpService) {}

  public consultar() {
    return this.http.doGet<Parkinglot[]>(`${environment.endpoint}/parking`);
  }

  public guardar(parkingLot: Parkinglot) {
    this.http.doPost<Parkinglot, any>(
      `${environment.endpoint}/parking`,
      parkingLot
    );
  }
}
