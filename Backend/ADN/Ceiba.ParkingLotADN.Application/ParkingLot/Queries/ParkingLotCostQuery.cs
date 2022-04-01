using Ceiba.ParkingLotADN.Application.ParkingLot.Queries;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ceiba.ParkingLotADN.Application.ParkingLot.Queries
{
    public record ParkingLotCostQuery([Required] Guid Id) : IRequest<decimal>;
}
