using Domain.Parameters;
using Domain.ResponseHelpers;
using MediatR;

namespace Domain.Queries.Persons.Find;

public class FindPersonsQuery : IRequest<PersonResponse>
{
    public FindPersonsParameters Parameters { get; set; }

    public FindPersonsQuery(FindPersonsParameters parameters)
    {
        Parameters = parameters;
    }
}