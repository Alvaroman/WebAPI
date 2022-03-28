import { Component, OnInit } from "@angular/core";
import { Parkinglot } from "@home/shared/model/parkinglot";
import { ParkinglotService } from "../../shared/service/parkintlot.service";
import { FormControl, FormGroup, Validators } from "@angular/forms";
@Component({
  selector: "app-create-parkinglot",
  templateUrl: "./create-parkinglot.component.html",
  styleUrls: ["./create-parkinglot.component.css"],
})
export class CreateParkinglotComponent implements OnInit {
  parkingLots: Parkinglot[];
  parkinglotForm: FormGroup;
  constructor(protected service: ParkinglotService) {}

  ngOnInit(): void {
    this.getParkingLotData();
    this.buildParkingLotForm();
  }
  getParkingLotData() {
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
  onSubmit() {
    console.log(this.parkinglotForm);
    // let newParkingLot: Parkinglot = {
    //   cylinder: <number>parkinglotForm.value.cylinder,
    //   plate: <string>parkinglotForm.value.plate,
    //   vehicleType: <number>parkinglotForm.value.vehicleType,
    //   id: "",
    //   finishedAt: new Date(),
    //   startedAt: new Date(),
    //   status: false,
    // };
    this.service.save(this.parkinglotForm.value).subscribe((resp) => {
      console.log(resp);
      this.parkinglotForm.reset();
      this.getParkingLotData();
    });
  }
  private buildParkingLotForm() {
    this.parkinglotForm = new FormGroup({
      id: new FormControl(""),
      cylinder: new FormControl("", [Validators.required]),
      plate: new FormControl("", [Validators.required]),
      vehicleType: new FormControl("", [Validators.required]),
    });
  }
}
