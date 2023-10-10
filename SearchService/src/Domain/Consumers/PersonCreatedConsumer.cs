using AutoMapper;
using Domain.Entities;
using Domain.Events;
using MassTransit;
using MongoDB.Entities;

namespace Domain.Consumers;

public class PersonCreatedConsumer : IConsumer<PersonCreatedEvent>
{
    private readonly IMapper _mapper;

    public PersonCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<PersonCreatedEvent> context)
    {
        Console.WriteLine("---> Consumindo criação de pessoa: " + context.Message.Id);

        var person = _mapper.Map<Person>(context.Message);

        await person.SaveAsync();
    }
}