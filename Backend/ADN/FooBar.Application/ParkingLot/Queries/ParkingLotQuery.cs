using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Application.Person.Queries
{
    public record ParkingLotQuery([Required] Guid Id) : IRequest<ParkingLotDto>;
}
