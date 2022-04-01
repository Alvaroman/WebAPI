using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ceiba.ParkingLotADN.Application.ParkingLot.Commands
{
    public record ParkingLotReleaseAsyncCommand(
        [Required] Guid id) 
        : IRequest<decimal>;
}
