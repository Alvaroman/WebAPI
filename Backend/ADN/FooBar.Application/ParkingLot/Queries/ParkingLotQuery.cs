using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FooBar.Application.ParkingLot.Queries
{
    public record ParkingLotQuery([Required] Guid Id) : IRequest<ParkingLotDto>;
}
