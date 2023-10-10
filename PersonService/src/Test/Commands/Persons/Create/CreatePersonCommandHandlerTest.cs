using AutoFixture;
using AutoMapper;
using Domain.Commands.Persons.Create;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Mappers;
using MassTransit;
using MediatR;
using Moq;
using Xunit;

namespace Test.Commands.Persons.Create;

public class CreatePersonCommandHandlerTest
{
    private readonly IMapper _mapper;

    public CreatePersonCommandHandlerTest()
    {
        _mapper = new MapperConfiguration(options => options.AddProfile<PersonProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidData_ReturnsUnitValue()
    {
        var repository = new Mock<IPersonRepository>();
        var publishEndpoint = new Mock<IPublishEndpoint>();

        var request = new Fixture().Create<CreatePersonCommand>();
        var handler = new CreatePersonCommandHandler(
            repository.Object,
            publishEndpoint.Object,
            _mapper);

        var response = await handler.Handle(request, default);

        Assert.Equal(Unit.Value, response);

        repository.Verify(x => x.CreateAsync(It.IsAny<Person>()), Times.Once);
    }
}