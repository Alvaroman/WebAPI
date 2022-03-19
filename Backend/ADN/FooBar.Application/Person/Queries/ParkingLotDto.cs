namespace FooBar.Application.Person.Queries
{
    public class ParkingLotDto
    {
        public Guid Id { get; set; }
        public int VehicleType { get; set; } = default!;
        public string Plate { get; set; } = default!;
        public int Cylinder { get; set; }
        public DateTime StartAt { get; set; } = default!;
        public DateTime FinishedAt { get; set; } = default!;
    }
}
