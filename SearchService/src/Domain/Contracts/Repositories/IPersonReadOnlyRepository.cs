using Domain.Parameters;
using Domain.ResponseHelpers;

namespace Domain.Contracts.Repositories;

public interface IPersonReadOnlyRepository
{
    Task<PersonResponse> FindAsync(FindPersonsParameters parameters);
}