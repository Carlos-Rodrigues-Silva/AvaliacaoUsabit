using Domain.Entities;

namespace Domain.ResponseHelpers;

public class PersonResponse
{
    public IReadOnlyCollection<Person> Results { get; set; }
    public int PageCount { get; set; }
    public long TotalCount { get; set; }
}