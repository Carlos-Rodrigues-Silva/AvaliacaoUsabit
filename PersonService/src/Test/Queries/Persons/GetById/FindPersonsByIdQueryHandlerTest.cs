using AutoFixture;
using Domain.Entities;
using Domain.Queries.Persons.GetById;
using Moq;
using Test.Mocks;
using Xunit;

namespace Test.Queries.Persons.GetById;

public class FindPersonsByIdQueryHandlerTest
{
    [Fact]
    public async Task Handle_ExistingId_ReturnsPerson()
    {
        var id = Guid.NewGuid();

        var expected = new Fixture().Create<Person>();

        var repository = new PersonReadOnlyRepositoryMock()
            .SetupSuccessGetById(id, expected)
            .Instance;

        var request = new GetPersonsByIdQuery(id);
        var handler = new GetPersonsByIdQueryHandler(repository.Object);

        var response = await handler.Handle(request, default);

        Assert.Equal(expected, response);

        repository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public async Task Handle_NonExistentId_ReturnsNull()
    {
        var id = Guid.NewGuid();

        var repository = new PersonReadOnlyRepositoryMock()
            .SetupFailGetById(id)
            .Instance;

        var request = new GetPersonsByIdQuery(id);
        var handler = new GetPersonsByIdQueryHandler(repository.Object);

        var response = await handler.Handle(request, default);

        Assert.Null(response);

        repository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
    }
}