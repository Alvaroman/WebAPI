namespace Ceiba.ParkingLotADN.Application.ParkingLot.Queries
{
    public class ParkingLotDto
    {
        public Guid Id { get; set; }
        public int VehicleType { get; set; } = default!;
        public string Plate { get; set; } = default!;
        public int Cylinder { get; set; }
        public DateTime StartedAt { get; set; } = default!;
        public DateTime FinishedAt { get; set; } = default!;
        public bool Status { get; set; } = default!;
    }
}
