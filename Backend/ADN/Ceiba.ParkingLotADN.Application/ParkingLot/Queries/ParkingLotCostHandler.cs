using Ceiba.ParkingLotADN.Domain.Services;
using MediatR;
namespace Ceiba.ParkingLotADN.Application.ParkingLot.Queries
{
    public class ParkingLotCostHandler : IRequestHandler<ParkingLotCostQuery, decimal>
    {
        private readonly ParkingLotService _parkingLotService;
        public ParkingLotCostHandler(ParkingLotService parkingLotService) => this._parkingLotService = parkingLotService;

        public Task<decimal> Handle(ParkingLotCostQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");
            return _parkingLotService.GetParkingCostAsync(request.Id);
        }
    }
}
