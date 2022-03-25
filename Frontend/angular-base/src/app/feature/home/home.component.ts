import { Component, OnInit } from "@angular/core";
import { Parkinglot } from "./shared/model/ParkingLot";
import { ProductoService } from "@producto/shared/service/producto.service";
// import { BrowserModule } from '@angular/platform-browser';
// import { NgxChartsModule } from '@swimlane/ngx-charts';
@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styles: [],
})
export class HomeComponent implements OnInit {
  single: any[];
  multi: any[];
  view: [number, number] = [900, 600];
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
  xAxisLabel: string = "Year";
  yAxisLabel: string = "Population";
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
      new Set(
        this.parkingLots
          .filter((x) => x.vehicleType == 1)
          .map((x) => new Date(x.startedAt).toLocaleDateString())
      ).forEach((date) => {
        carsSeries.push({
          name: date,
          value: this.parkingLots.filter(
            (x) =>
              x.vehicleType == 1 &&
              new Date(x.startedAt).toLocaleDateString() == date
          ).length,
        });
      });
      let seriesDates = [{ name: "Car", series: carsSeries }];
      let motorcycleSeries: any[] = [];
      new Set(
        this.parkingLots
          .filter((x) => x.vehicleType == 2)
          .map((x) => new Date(x.startedAt).toLocaleDateString())
      ).forEach((date) => {
        motorcycleSeries.push({
          name: date,
          value: this.parkingLots.filter(
            (x) =>
              x.vehicleType == 2 &&
              new Date(x.startedAt).toLocaleDateString() == date
          ).length,
        });
      });
      seriesDates.push({ name: "Motorcicle", series: motorcycleSeries });
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
