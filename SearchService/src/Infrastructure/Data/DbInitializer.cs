using Domain.Entities;
using MongoDB.Driver;
using MongoDB.Entities;
using System.Text.Json;

namespace Infrastructure.Data;

public class DbInitializer
{
    public static async Task InitDb(string connectionString)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings.FromConnectionString(connectionString));

        await DB.Index<Person>()
            .Key(x => x.Name, KeyType.Text)
            .Key(x => x.Email, KeyType.Text)
            .Key(x => x.Gender, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Person>();

        if(count == 0)
        {
            Console.WriteLine("Nenhum dado para ser cadastrado");

            var itemData = await File.ReadAllTextAsync("..\\Infrastructure\\Data\\persons.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var items = JsonSerializer.Deserialize<List<Person>>(itemData, options);

            await DB.SaveAsync(items);
        }
    }
}