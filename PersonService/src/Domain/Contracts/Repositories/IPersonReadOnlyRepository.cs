using Domain.Entities;

namespace Domain.Contracts.Repositories;

public interface IPersonReadOnlyRepository
{
    Task<List<Person>> FindAsync();
    Task<Person> GetByIdAsync(Guid id);
}