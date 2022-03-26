export class Parkinglot {
    id: string;
    vehicleType: number;
    plate: string;
    cylinder: number;
    startedAt: Date;
    finishedAt: Date;
    status: boolean;
  
    constructor(
      id: string,
      vehicleType: number,
      plate: string,
      cylinder: number,
      startedAt: Date,
      finishedAt: Date,
      status: boolean
    ) {
      this.id = id;
      this.vehicleType = vehicleType;
      this.plate = plate;
      this.cylinder = cylinder;
      this.startedAt = startedAt;
      this.finishedAt = finishedAt;
      this.status = status;
    }
  
  }
  