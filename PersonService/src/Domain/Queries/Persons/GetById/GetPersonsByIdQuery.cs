using Domain.Entities;
using MediatR;

namespace Domain.Queries.Persons.GetById;

public class GetPersonsByIdQuery : IRequest<Person>
{
    public Guid Id { get; set; }

    public GetPersonsByIdQuery(Guid id)
    {
        Id = id;
    }
}