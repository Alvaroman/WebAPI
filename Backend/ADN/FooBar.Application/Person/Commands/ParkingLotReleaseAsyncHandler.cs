using FooBar.Domain.Services;
using MediatR;

namespace FooBar.Application.Person.Commands
{
    public class ParkingLotReleaseAsyncHandler : AsyncRequestHandler<ParkingLotReleaseAsyncCommand>
    {
        private readonly ParkingLotService _parkingLotService;

        public ParkingLotReleaseAsyncHandler(ParkingLotService parkingLotService) => this._parkingLotService = parkingLotService;

        protected override async Task Handle(ParkingLotReleaseAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await _parkingLotService.ReleaseParkingLotAsync(request.id);
        }
    }

}
