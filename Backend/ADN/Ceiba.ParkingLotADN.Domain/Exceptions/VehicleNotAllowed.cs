namespace Ceiba.ParkingLotADN.Domain.Exception
{
    public class VehicleNotAllowed : AppException
    {
        public VehicleNotAllowed() { }
        public VehicleNotAllowed(string message) : base(message) { }
        public VehicleNotAllowed(string message, System.Exception inner) : base(message, inner) { }
        protected VehicleNotAllowed(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
