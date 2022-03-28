import { Component, OnInit } from "@angular/core";
import { Parkinglot } from "../../shared/model/parkinglot";
import { ParkinglotService } from "../../shared/service/parkintlot.service";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styles: [],
})
export class DashboardComponent implements OnInit {
  single: any[];
  multi: any[];
  viewLine: [number, number] = [1200, 500];
  viewPie: [number, number] = [600, 305];
  carDayAverage: number = 0;
  motorcycleDayAverage: number = 0;
  colorScheme = {
    domain: ["#770A0A", "#40770A"],
  };
  // options
  gradient: boolean = true;
  showLegend: boolean = true;
  showLabels: boolean = true;
  isDoughnut: boolean = false;

  legend: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = "Date";
  yAxisLabel: string = "Quantity";
  timeline: boolean = true;

  public parkingLots: Parkinglot[] = [];

  constructor(protected HomeService: ParkinglotService) {}

  onSelect(data: any): void {
    console.log("Item clicked", JSON.parse(JSON.stringify(data)));
  }
  onActivate(data: any): void {
    console.log("Activate", JSON.parse(JSON.stringify(data)));
  }
  onDeactivate(data: any): void {
    console.log("Deactivate", JSON.parse(JSON.stringify(data)));
  }
  ngOnInit(): void {
    this.HomeService.get().subscribe((resp) => {
      this.parkingLots = resp;
      console.log(this.parkingLots);

      this.setCarData();
      this.setMotorcycleData();
      let myResults = this.multi;
      let mySingle = this.single;
      Object.assign(this, { myResults });
      Object.assign(this, { mySingle });
    });
  }
  setCarData() {
    let carsSeries: any[] = [];
    let carDates = new Set(
      this.parkingLots
        .sort((a, b) => {
          return new Date(a.startedAt) > new Date(b.startedAt) ? 1 : -1;
        })
        .filter((x) => x.vehicleType == 1)
        .map((x) => new Date(x.startedAt).toLocaleDateString())
    );
    carDates.forEach((date) => {
      let count = this.parkingLots.filter(
        (x) =>
          x.vehicleType == 1 &&
          new Date(x.startedAt).toLocaleDateString() == date
      ).length;
      carsSeries.push({
        name: date,
        value: count,
      });
      this.carDayAverage += count;
    });
    this.carDayAverage = parseFloat(
      (this.carDayAverage / carDates.size).toFixed(2)
    );
    if (this.multi) {
      this.multi.push({ name: "Cars", series: carsSeries });
    } else {
      this.multi = [{ name: "Cars", series: carsSeries }];
    }
    if (this.single) {
      this.single.push({
        name: "Cars",
        value: this.parkingLots.filter(
          (vehicle) => vehicle.status && vehicle.vehicleType == 1
        ).length,
      });
    } else {
      this.single = [
        {
          name: "Cars",
          value: this.parkingLots.filter(
            (vehicle) => vehicle.status && vehicle.vehicleType == 1
          ).length,
        },
      ];
    }
  }
  setMotorcycleData() {
    let motorcycleSeries: any[] = [];
    console.log(
      this.parkingLots.sort((a, b) => {
        return new Date(a.startedAt) > new Date(b.startedAt) ? 1 : -1;
      })
    );
    let motorcycleDates = new Set(
      this.parkingLots
        .sort((a, b) => {
          return new Date(a.startedAt) > new Date(b.startedAt) ? 1 : -1;
        })
        .filter((x) => x.vehicleType == 2)
        .map((x) => new Date(x.startedAt).toLocaleDateString())
    );
    motorcycleDates.forEach((date) => {
      let count = this.parkingLots.filter(
        (x) =>
          x.vehicleType == 2 &&
          new Date(x.startedAt).toLocaleDateString() == date
      ).length;
      motorcycleSeries.push({
        name: date,
        value: count,
      });
      this.motorcycleDayAverage += count;
    });

    this.motorcycleDayAverage = parseFloat(
      (this.motorcycleDayAverage / motorcycleDates.size).toFixed(2)
    );

    this.multi.push({ name: "Motorcicles", series: motorcycleSeries });
    this.single.push({
      name: "Motorcycles",
      value: this.parkingLots.filter(
        (vehicle) => vehicle.status && vehicle.vehicleType == 2
      ).length,
    });
  }
}
