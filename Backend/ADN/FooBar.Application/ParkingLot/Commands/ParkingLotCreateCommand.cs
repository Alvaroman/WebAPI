using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FooBar.Application.ParkingLot.Commands
{
    public record ParkingLotCreateCommand([Required] int VehicleType,
        [Required] string Plate,
        [Required] DateTime StartAt,
        [Required] int Cylinder
    ) : IRequest;
}
