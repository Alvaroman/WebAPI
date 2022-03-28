using FooBar.Application.ParkingLot.Queries;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FooBar.Application.ParkingLot.Queries
{
    public record ParkingLotCostQuery([Required] Guid Id) : IRequest<decimal>;
}
