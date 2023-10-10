using Domain.Contracts.Repositories;
using Domain.Entities;
using Moq;

namespace Test.Mocks;

public class PersonReadOnlyRepositoryMock
{
    public readonly Mock<IPersonReadOnlyRepository> Instance;

    public PersonReadOnlyRepositoryMock()
    {
        Instance = new Mock<IPersonReadOnlyRepository>();
    }

    public PersonReadOnlyRepositoryMock SetupSuccessGetById(Guid id, Person expected)
    {
        Instance
            .Setup(x => x.GetByIdAsync(id))
            .ReturnsAsync(expected);

        return this;
    }

    public PersonReadOnlyRepositoryMock SetupFailGetById(Guid id)
    {
        Instance
            .Setup(x => x.GetByIdAsync(id))
            .Returns(Task.FromResult<Person>(null));

        return this;
    }

    public PersonReadOnlyRepositoryMock SetupSuccessFind(List<Person> expected)
    {
        Instance
            .Setup(x => x.FindAsync())
            .ReturnsAsync(expected);

        return this;
    }
}
