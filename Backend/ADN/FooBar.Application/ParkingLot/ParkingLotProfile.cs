using AutoMapper;
using FooBar.Application.ParkingLot.Queries;

namespace FooBar.Application.Person
{
    public class ParkingLotProfile : Profile
    {
        public ParkingLotProfile()
        {
            CreateMap<Domain.Entities.ParkingLot, ParkingLotDto>().ReverseMap();
        }
    }
}
