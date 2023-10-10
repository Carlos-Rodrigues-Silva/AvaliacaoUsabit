using Domain.Contracts.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonReadOnlyRepository : IPersonReadOnlyRepository
{
    private readonly DataContext _dataContext;

    public PersonReadOnlyRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Person>> FindAsync()
    {
        return await _dataContext.Persons.ToListAsync();
    }

    public async Task<Person> GetByIdAsync(Guid id)
    {
        return await _dataContext.Persons.FirstOrDefaultAsync(x => x.Id == id);
    }
}