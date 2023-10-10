using Domain.Contracts.Repositories;
using Domain.Entities;
using MediatR;

namespace Domain.Queries.Persons.GetById;

public class GetPersonsByIdQueryHandler : IRequestHandler<GetPersonsByIdQuery, Person>
{
    private readonly IPersonReadOnlyRepository _personReadOnlyRepository;

    public GetPersonsByIdQueryHandler(IPersonReadOnlyRepository personReadOnlyRepository)
    {
        _personReadOnlyRepository = personReadOnlyRepository;
    }

    public async Task<Person> Handle(GetPersonsByIdQuery request, CancellationToken cancellationToken)
    {
        return await _personReadOnlyRepository.GetByIdAsync(request.Id);
    }
}