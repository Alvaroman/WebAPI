using MediatR;
namespace FooBar.Application.VehicleType.Queries
{
    public record VehicleTypeQuery() : IRequest<IEnumerable<VehicleTypeDTO>>;
}
