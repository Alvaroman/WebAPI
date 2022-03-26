import { Component, OnInit } from "@angular/core";
import { Parkinglot } from "./shared/model/ParkingLot";
import { ProductoService } from "@producto/shared/service/producto.service";
@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styles: [],
})
export class HomeComponent implements OnInit {
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

  constructor(protected HomeService: ProductoService) {}

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
    this.HomeService.consultar().subscribe((resp) => {
      this.parkingLots = resp.filter((x) => x.status);
      console.log(this.parkingLots);
      let carsSeries: any[] = [];
      let carDates = new Set(
        this.parkingLots
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
      this.carDayAverage = this.carDayAverage / carDates.size;
      let seriesDates = [{ name: "Cars", series: carsSeries }];
      let motorcycleSeries: any[] = [];
      let motorcycleDates = new Set(
        this.parkingLots
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
      this.motorcycleDayAverage =
        this.motorcycleDayAverage / motorcycleDates.size;

      seriesDates.push({ name: "Motorcicles", series: motorcycleSeries });
      this.single = [
        {
          name: "Motorcycles",
          value: this.parkingLots.filter((x) => x.vehicleType == 2).length,
        },
        {
          name: "Cars",
          value: this.parkingLots.filter((x) => x.vehicleType == 1).length,
        },
      ];
      this.multi = seriesDates;
      console.log(this.multi);
      console.log(this.single);

      let myResults = this.multi;
      let mySingle = this.single;

      Object.assign(this, { myResults });
      Object.assign(this, { mySingle });
    });
  }
}
