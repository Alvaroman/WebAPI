using AutoMapper;
using Ceiba.ParkingLotADN.Application.ParkingLot.Queries;

namespace Ceiba.ParkingLotADN.Application.Person
{
    public class ParkingLotProfile : Profile
    {
        public ParkingLotProfile()
        {
            CreateMap<Domain.Entities.ParkingLot, ParkingLotDto>().ReverseMap();
        }
    }
}
