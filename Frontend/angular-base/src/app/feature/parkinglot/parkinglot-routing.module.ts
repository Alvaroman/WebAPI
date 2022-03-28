import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CreateParkinglotComponent } from "./components/create-parkinglot/create-parkinglot.component";
import { DashboardComponent } from "./components/dashboard/dashboard.component";

const routes: Routes = [
  {
    path: "parkinglot",
    component: DashboardComponent,
  },
  {
    path: "create",
    component: CreateParkinglotComponent,
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ParkingLotRoutingModule {}
