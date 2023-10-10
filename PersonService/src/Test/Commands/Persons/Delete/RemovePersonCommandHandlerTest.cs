using AutoFixture;
using Domain.Commands.Persons.Delete;
using Domain.Contracts.Repositories;
using MassTransit;
using MediatR;
using Moq;
using Xunit;

namespace Test.Commands.Persons.Delete;

public class RemovePersonCommandHandlerTest
{
    [Fact]
    public async Task Handle_ValidData_ReturnsUnitValue()
    {
        var repository = new Mock<IPersonRepository>();
        var publishEndpoint = new Mock<IPublishEndpoint>();

        var request = new Fixture().Create<RemovePersonCommand>();
        var handler = new RemovePersonCommandHandler(
            repository.Object,
            publishEndpoint.Object);

        var response = await handler.Handle(request, default);

        Assert.Equal(Unit.Value, response);

        repository.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Once);
    }
}