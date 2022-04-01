using System;

namespace FooBar.Domain.Tests.ParkingLot
{
    public class ParkingLotDataBuilder
    {
        int VehicleType = default!;
        string Plate = default!;
        int Cylinder = default!;
        bool Status = default!;
        DateTime StartedAt = default!;
        DateTime? FinishedAt = default!;

        public Domain.Entities.ParkingLot Build()
        {
            Domain.Entities.ParkingLot parkingLot = new Entities.ParkingLot { Cylinder = Cylinder, FinishedAt = FinishedAt, Plate = Plate, StartedAt = StartedAt, Status = Status, VehicleType = VehicleType };
            return parkingLot;
        }
        public ParkingLotDataBuilder WithVehicleType(int type)
        {
            VehicleType= type;
            return this;
        }

        public ParkingLotDataBuilder WithStartAt(DateTime date)
        {
            StartedAt = date;
            return this;
        }

        public ParkingLotDataBuilder WithPlate(string plate)
        {
            Plate = plate;
            return this;
        }

        public ParkingLotDataBuilder WithCylinder(int cylinder)
        {
            Cylinder = cylinder;
            return this;
        }
        public ParkingLotDataBuilder WithStaus(bool status)
        {
            Status= status;
            return this;
        }
        public ParkingLotDataBuilder WithFinishedAt(DateTime date)
        {
            FinishedAt= date;
            return this;
        }
    }
}
