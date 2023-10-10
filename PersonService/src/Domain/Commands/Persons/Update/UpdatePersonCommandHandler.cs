using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Events;
using MassTransit;
using MediatR;

namespace Domain.Commands.Persons.Update;

public class UpdatePersonCommandhandler : IRequestHandler<UpdatePersonCommand, Unit>
{
    private readonly IPersonRepository _personRepository;
    private readonly IPersonReadOnlyRepository _personReadOnlyRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public UpdatePersonCommandhandler(
        IPersonRepository personRepository,
        IPersonReadOnlyRepository personReadOnlyRepository,
        IPublishEndpoint publishEndpoint,
        IMapper mapper)
    {
        _personRepository = personRepository;
        _personReadOnlyRepository = personReadOnlyRepository;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var personExist = _personReadOnlyRepository.GetByIdAsync(request.Id);

        if(personExist is not null)
        {
            var person = _mapper.Map(request, personExist.Result);

            var personUpdated = await _personRepository.UpdateAsync(person);

            var personUpdatedEvent = _mapper.Map<PersonUpdatedEvent>(personUpdated);

            await _publishEndpoint.Publish(personUpdatedEvent, cancellationToken);
        }

        return Unit.Value;
    }
}