import { Component, OnInit } from "@angular/core";
import { Parkinglot } from "@home/shared/model/parkinglot";
import { ParkinglotService } from "../../shared/service/parkintlot.service";

@Component({
  selector: "app-create-parkinglot",
  templateUrl: "./create-parkinglot.component.html",
  styleUrls: ["./create-parkinglot.component.css"],
})
export class CreateParkinglotComponent implements OnInit {
  parkingLots: Parkinglot[];
  constructor(protected service: ParkinglotService) {}

  ngOnInit(): void {
    this.service.get().subscribe((resp) => {
      this.parkingLots = resp
        .filter((vehicle) => vehicle.status)
        .sort((a, b) => {
          return new Date(a.startedAt) < new Date(b.startedAt) ? 1 : -1;
        });
    });
  }
  getStartedAtDatePart(id: string) {
    let parkingLotValue = this.parkingLots.find((x) => x.id == id);
    return parkingLotValue != undefined
      ? new Date(parkingLotValue?.startedAt).toLocaleTimeString()
      : "";
  }
  getStartedAtHourPart(id: string) {
    let parkingLotValue = this.parkingLots.find((x) => x.id == id);
    return parkingLotValue != undefined
      ? new Date(parkingLotValue?.startedAt).toLocaleDateString()
      : "";
  }
}
