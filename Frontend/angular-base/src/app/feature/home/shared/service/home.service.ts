import { Injectable } from '@angular/core';
import { HttpService } from '@core-service/http.service';
import { environment } from 'src/environments/environment';
import { Parkinglot } from '../model/parkinglot';

@Injectable()
export class HomeService {

  constructor(protected http: HttpService) {}

  public consultar() {
      console.log(`${environment.endpoint}/parkinglot`);
    return this.http.doGet<Parkinglot[]>(`${environment.endpoint}/parking`, this.http.optsName('consultar vehículos en parqueadero'));
  }
  public guardar(producto: Parkinglot) {
    return this.http.doPost<Parkinglot, boolean>(`${environment.endpoint}/productos`, producto,
                                                this.http.optsName('crear/actualizar productos'));
  }

  public eliminar(producto: Parkinglot) {
    return this.http.doDelete<boolean>(`${environment.endpoint}/productos/${producto.id}`,
                                                 this.http.optsName('eliminar productos'));
  }
}
