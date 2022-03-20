using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FooBar.Application.Person.Queries {
    public record PersonQuery([Required] Guid Id) : IRequest<PersonDto>;
    
}