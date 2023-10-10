using AutoMapper;
using Domain.Entities;
using Domain.Events;

namespace Domain.Mappers;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<PersonCreatedEvent, Person>();
        CreateMap<PersonUpdatedEvent, Person>();
    }
}