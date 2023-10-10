using Domain.Contracts.Repositories;
using Domain.Events;
using MassTransit;
using MediatR;

namespace Domain.Commands.Persons.Delete;

public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommand, Unit>
{
    private readonly IPersonRepository _personRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public RemovePersonCommandHandler(
        IPersonRepository personRepository,
        IPublishEndpoint publishEndpoint)
    {
        _personRepository = personRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Unit> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.DeleteAsync(request.Id);

        if(person is not null)
        {
            await _publishEndpoint.Publish<PersonDeletedEvent>(new { Id = person.Id.ToString()}, cancellationToken);
        }

        return Unit.Value;
    }
}