using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Events;
using MassTransit;
using MediatR;

namespace Domain.Commands.Persons.Create;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Unit>
{
    private readonly IPersonRepository _personRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public CreatePersonCommandHandler(
        IPersonRepository personRepository,
        IPublishEndpoint publishEndpoint,
        IMapper mapper)
    {
        _personRepository = personRepository;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);

        var personCreated = await _personRepository.CreateAsync(person);

        if(personCreated != null)
        {
            var personCreatedEvent = _mapper.Map<PersonCreatedEvent>(personCreated);

            await _publishEndpoint.Publish(personCreatedEvent, cancellationToken);
        }

        return Unit.Value;
    }
}