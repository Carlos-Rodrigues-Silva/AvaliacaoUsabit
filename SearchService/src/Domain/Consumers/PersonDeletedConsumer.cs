using Domain.Entities;
using Domain.Events;
using MassTransit;
using MongoDB.Entities;

namespace Domain.Consumers;

public class PersonDeletedConsumer : IConsumer<PersonDeletedEvent>
{
    public async Task Consume(ConsumeContext<PersonDeletedEvent> context)
    {
        Console.WriteLine("---> Consumindo remoção de pessoa: " + context.Message.Id);

        var result = await DB.DeleteAsync<Person>(context.Message.Id);

        if(!result.IsAcknowledged)
            throw new MessageException(typeof(PersonDeletedEvent), "Problema ao deletar registro!");
    }
}