using AutoFixture;
using Domain.Parameters;
using Domain.Queries.Persons.Find;
using Domain.ResponseHelpers;
using Moq;
using Test.Mocks;
using Xunit;

namespace Test.Queries.Persons.Find;

public class FindPersonsQueryHandlerTest
{
    [Fact]
    public async Task Handle_ValidFilter_ReturnsPersons()
    {
        var fixture = new Fixture();
        var expected = fixture.Create<PersonResponse>();
        var request = fixture.Create<FindPersonsQuery>();

        var repository = new PersonReadOnlyRepositoryMock()
            .SetupSuccessFind(request.Parameters, expected)
            .Instance;

        var handler = new FindPersonsQueryHandler(repository.Object);

        var response = await handler.Handle(request, default);

        Assert.Equal(expected, response);

        repository.Verify(x => x.FindAsync(It.IsAny<FindPersonsParameters>()), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidFilter_ReturnsEmptyResult()
    {
        var fixture = new Fixture();
        var expected = fixture.Create<PersonResponse>();
        var request = new Fixture().Create<FindPersonsQuery>();

        var repository = new PersonReadOnlyRepositoryMock()
            .SetupSuccessFind(request.Parameters, expected)
            .Instance;

        var handler = new FindPersonsQueryHandler(repository.Object);

        var response = await handler.Handle(request, default);

        Assert.Equal(expected, response);

        repository.Verify(x => x.FindAsync(It.IsAny<FindPersonsParameters>()), Times.Once);
    }
}