using FooBar.Application.ParkingLot.Commands;
using FooBar.Domain.Services;
using MediatR;

namespace FooBar.Application.Person.Commands
{
    public class ParkingLotCreateHandler : AsyncRequestHandler<ParkingLotCreateCommand>
    {
        private readonly ParkingLotService _parkingLotService;

        public ParkingLotCreateHandler(ParkingLotService parkingLotService) => this._parkingLotService = parkingLotService ?? throw new ArgumentNullException(nameof(parkingLotService));

        protected override async Task Handle(ParkingLotCreateCommand request, CancellationToken cancellationToken)
        {
            _ = new ArgumentNullException(nameof(request), "request object needed to handle this task");
            await _parkingLotService.RegisterParkingLotAsync(new Domain.Entities.ParkingLot { Plate = request.Plate, Cylinder = request.Cylinder, StartedAt = request.StartAt, VehicleType = request.VehicleType, Status = true });
        }
    }
}
