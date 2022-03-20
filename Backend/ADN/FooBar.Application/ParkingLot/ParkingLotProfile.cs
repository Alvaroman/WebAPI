using AutoMapper;
using FooBar.Application.Person.Queries;
using FooBar.Domain.Entities;

namespace FooBar.Application.Person
{
    public class ParkingLotProfile : Profile
    {
        public ParkingLotProfile()
        {
            CreateMap<ParkingLot, ParkingLotDto>().ReverseMap();
        }
    }
}
