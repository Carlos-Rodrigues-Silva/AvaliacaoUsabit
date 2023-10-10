using Domain.Entities;
using MediatR;

namespace Domain.Queries.Persons.Find;

public class FindPersonsQuery : IRequest<List<Person>>
{ }