using AutoMapper;
using Domain.Commands.Persons.Create;
using Domain.Commands.Persons.Update;
using Domain.Entities;
using Domain.Events;

namespace Domain.Mappers;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<CreatePersonCommand, Person>();
        CreateMap<Person, PersonCreatedEvent>();

        CreateMap<UpdatePersonCommand, Person>();
        CreateMap<Person, PersonUpdatedEvent>();
    }
}