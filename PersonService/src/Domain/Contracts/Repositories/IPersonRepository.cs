using Domain.Entities;

namespace Domain.Contracts.Repositories;

public interface IPersonRepository
{
    Task<Person> CreateAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task<Person> DeleteAsync(Guid id);
}