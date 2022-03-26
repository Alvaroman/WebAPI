import { BrowserModule } from "@angular/platform-browser";
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";

import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import { HomeComponent } from "@home/home.component";
import { ProductoModule } from "@producto/producto.module";
import { CoreModule } from "@core/core.module";
import { CookieService } from "ngx-cookie-service";
import { NgxChartsModule } from "@swimlane/ngx-charts";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ParkingLotModule } from "./feature/parkinglot/parkinglot.module";

@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ProductoModule,
    ParkingLotModule,
    CoreModule,
    NgxChartsModule,
    BrowserAnimationsModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
