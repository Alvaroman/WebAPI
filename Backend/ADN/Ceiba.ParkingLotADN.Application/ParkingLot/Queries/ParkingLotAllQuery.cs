
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ceiba.ParkingLotADN.Application.ParkingLot.Queries
{
    public record ParkingLotAllQuery() : IRequest<IEnumerable<ParkingLotDto>>;
}
