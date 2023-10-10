using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}