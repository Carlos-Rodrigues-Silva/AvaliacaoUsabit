using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Parameters;
using Domain.ResponseHelpers;
using MongoDB.Entities;

namespace Infrastructure.Repositories;

public class PersonReadOnlyRepository : IPersonReadOnlyRepository
{
    public async Task<PersonResponse> FindAsync(FindPersonsParameters parameters)
    {
        var query = DB.PagedSearch<Person>();

        query.Sort(x => x.Ascending(a => a.Name));

        if (!string.IsNullOrEmpty(parameters.SearchTerm))
        {
            query.Match(Search.Full, parameters.SearchTerm).SortByTextScore();
        }

        query.PageNumber(parameters.PageNumber);
        query.PageSize(parameters.PageSize);

        var (Results, TotalCount, PageCount) = await query.ExecuteAsync();

        var personResponse = new PersonResponse
        {
            Results = Results,
            PageCount = PageCount,
            TotalCount = TotalCount
        };

        return personResponse;
    }
}