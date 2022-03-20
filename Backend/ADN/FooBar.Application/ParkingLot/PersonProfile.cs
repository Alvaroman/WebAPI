using FooBar.Application.Person.Queries;
using AutoMapper;

namespace FooBar.Application.Person
{

    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<FooBar.Domain.Entities.Person, PersonDto>().ReverseMap();
        }
    }
}