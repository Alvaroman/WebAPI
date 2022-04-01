using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ceiba.ParkingLotADN.Application.ParkingLot.Commands
{
    public record ParkingLotCreateCommand([Required] int VehicleType,
        [Required] string Plate,
        [Required] DateTime StartedAt,
        [Required] int Cylinder
    ) : IRequest;
}
