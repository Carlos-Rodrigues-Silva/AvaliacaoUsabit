using Domain.Contracts.Repositories;
using Domain.Entities;
using MediatR;

namespace Domain.Queries.Persons.Find;

public class FindPersonsQueryHandler : IRequestHandler<FindPersonsQuery, List<Person>>
{
    private readonly IPersonReadOnlyRepository _personReadOnlyRepository;

    public FindPersonsQueryHandler(IPersonReadOnlyRepository personReadOnlyRepository)
    {
        _personReadOnlyRepository = personReadOnlyRepository;
    }

    public async Task<List<Person>> Handle(FindPersonsQuery request, CancellationToken cancellationToken)
    {
        return await _personReadOnlyRepository.FindAsync();
    }
}