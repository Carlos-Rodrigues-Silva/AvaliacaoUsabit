using AutoMapper;
using Domain.Entities;
using Domain.Events;
using MassTransit;
using MongoDB.Entities;

namespace Domain.Consumers;

public class PersonUpdatedConsumer : IConsumer<PersonUpdatedEvent>
{
    private readonly IMapper _mapper;

    public PersonUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<PersonUpdatedEvent> context)
    {
        Console.WriteLine("---> Consumindo atualização de pessoa: " + context.Message.Id);

        var person = _mapper.Map<Person>(context.Message);

        var result = await DB.Update<Person>()
            .Match(a => a.ID == context.Message.Id)
            .ModifyOnly(x => new
            {
                x.Name,
                x.Email,
                x.PhoneNumber,
                x.DateOfBirth,
                x.Gender,
                x.Cpf
            }, person)
            .ExecuteAsync();

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(PersonUpdatedEvent), "Problema ao atualizar registro!");
    }
}