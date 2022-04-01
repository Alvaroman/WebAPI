using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ceiba.ParkingLotADN.Application.ParkingLot.Queries
{
    public record ParkingLotQuery([Required] Guid Id) : IRequest<ParkingLotDto>;
}
