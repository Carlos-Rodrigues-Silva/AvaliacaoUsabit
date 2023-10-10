using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Context;

public class SeedData
{
    public static async Task SeedDbData(DataContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var persons = new List<Person>();

            if (!context.Persons.Any())
            {
                var firstPerson = new Person
                {
                    Id = new Guid("afaf13cd-5268-46a4-8309-488bcfb0b91c"),
                    Name = "Maria",
                    Email = "maria@email.com",
                    PhoneNumber = "(67) 98310-5156",
                    DateOfBirth = new DateTime(1993, 01, 01),
                    Gender = "feminino",
                    Cpf = "620.201.870-43",
                };
                persons.Add(firstPerson);

                var secondPerson = new Person
                {
                    Id = new Guid("1d195141-611e-4dcd-8549-2ac44c5948d3"),
                    Name = "João",
                    Email = "joao@email.com",
                    PhoneNumber = "(99) 99372-7623",
                    DateOfBirth = new DateTime(1993, 12, 23),
                    Gender = "masculino",
                    Cpf = "897.348.550-42",
                };
                persons.Add(secondPerson);

                var thirdPerson = new Person
                {
                    Id = new Guid("d86ed77b-ceea-4307-8811-8e647464b589"),
                    Name = "Fernanda",
                    Email = "fernanda@email.com",
                    PhoneNumber = "(82) 97971-6350",
                    DateOfBirth = new DateTime(1993, 12, 23),
                    Gender = "feminino",
                    Cpf = "111.952.040-19",
                };
                persons.Add(thirdPerson);
            }
            
            await context.AddRangeAsync(persons);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<SeedData>();
            logger.LogError(ex.Message);
        }
    }
}
