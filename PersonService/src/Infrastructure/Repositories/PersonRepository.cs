using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly DataContext _dataContext;

    public PersonRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Person> CreateAsync(Person person)
    {
        await _dataContext.Persons.AddAsync(person);
        await _dataContext.SaveChangesAsync();

        return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
        _dataContext.Persons.Update(person);
        await _dataContext.SaveChangesAsync();

        return person;
    }

    public async Task<Person> DeleteAsync(Guid id)
    {
        var personExist = await _dataContext.Persons.FirstOrDefaultAsync(x => x.Id == id);

        if (personExist is not null)
        {
            _dataContext.Persons.Remove(personExist);
            var result = await _dataContext.SaveChangesAsync();
        }

        return personExist;
    }
}