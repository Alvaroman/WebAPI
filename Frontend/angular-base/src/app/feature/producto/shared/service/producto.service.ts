import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Producto } from "../model/producto";
import { Parkinglot } from "../../../home/shared/model/parkinglot";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ProductoService {
  constructor(protected http: HttpClient) {}

  public consultar() {
    console.log(`${environment.endpoint}/parking`);
    return this.http.get<Parkinglot[]>(`${environment.endpoint}/parking`);
  }

  public guardar(producto: Producto) {
    this.http.post(`${environment.endpoint}/productos`, producto, {
      headers: {
        "Access-Control-Allow-Origin": "http://localhost:4200",
      },
    });
  }

  public eliminar(producto: Producto) {
    this.http.delete(`${environment.endpoint}/producto/${producto.id}`);
  }
}
