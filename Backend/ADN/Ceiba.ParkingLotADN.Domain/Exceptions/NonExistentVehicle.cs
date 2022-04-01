namespace Ceiba.ParkingLotADN.Domain.Exception
{
    public class NonExistentVehicle : AppException
    {
        public NonExistentVehicle() { }
        public NonExistentVehicle(string message) : base(message) { }
        public NonExistentVehicle(string message, System.Exception inner) : base(message, inner) { }
        protected NonExistentVehicle(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
