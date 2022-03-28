using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FooBar.Application.ParkingLot.Commands
{
    public record ParkingLotReleaseAsyncCommand(
        [Required] Guid id) 
        : IRequest<decimal>;
}
