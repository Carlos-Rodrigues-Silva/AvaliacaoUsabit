using Domain.Contracts.Repositories;
using Domain.ResponseHelpers;
using MediatR;

namespace Domain.Queries.Persons.Find;

public class FindPersonsQueryHandler : IRequestHandler<FindPersonsQuery, PersonResponse>
{
    private readonly IPersonReadOnlyRepository _personReadOnlyRepository;

    public FindPersonsQueryHandler(IPersonReadOnlyRepository personReadOnlyRepository)
    {
        _personReadOnlyRepository = personReadOnlyRepository;
    }

    public async Task<PersonResponse> Handle(FindPersonsQuery request, CancellationToken cancellationToken)
    {
        return await _personReadOnlyRepository.FindAsync(request.Parameters);
    }
}