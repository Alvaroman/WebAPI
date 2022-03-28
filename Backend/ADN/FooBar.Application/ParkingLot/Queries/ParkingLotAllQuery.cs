
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FooBar.Application.ParkingLot.Queries
{
    public record ParkingLotAllQuery() : IRequest<IEnumerable<ParkingLotDto>>;
}
