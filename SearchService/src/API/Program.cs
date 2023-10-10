using Domain.Consumers;
using Domain.Contracts.Repositories;
using Domain.Mappers;
using Domain.Queries.Persons.Find;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonReadOnlyRepository, PersonReadOnlyRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(FindPersonsQueryHandler).Assembly));
builder.Services.AddMassTransit(x =>
{
    x.AddConsumersFromNamespaceContaining<PersonCreatedConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("search", false));

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddAutoMapper(typeof(PersonProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    await DbInitializer.InitDb(app.Configuration.GetConnectionString("MongoDbConnection"));
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

app.Run();
