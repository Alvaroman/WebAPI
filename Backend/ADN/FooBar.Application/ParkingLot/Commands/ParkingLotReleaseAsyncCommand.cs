using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FooBar.Application.Person.Commands
{
    public record ParkingLotReleaseAsyncCommand(
        [Required] Guid id) 
        : IRequest<decimal>;
}
