using FooBar.Domain.Enums;
using FooBar.Domain.Exception;

namespace FooBar.Domain.Services.ParkingPicoPlacaState
{
    [DomainService]
    public class PicoPlacaContext
    {
        private PicoPlacaState State { get; set; } = default!;
        public bool ValidatePicoPlaca(string plate, VehicleType vehicleType)
        {
            this.State = vehicleType switch
            {
                VehicleType.Car => new CarPicoPlaca(),
                VehicleType.Motorcycle => new MotorciclePicoPlaca(),
                _ => throw new VehicleNotAllowed("This vehicle type is not considered")
            };
            return this.State.PicoPlacaValidator(plate);
        }
    }
}
