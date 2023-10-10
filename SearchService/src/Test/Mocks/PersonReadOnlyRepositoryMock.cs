using Domain.Contracts.Repositories;
using Domain.Parameters;
using Domain.ResponseHelpers;
using Moq;

namespace Test.Mocks;

public class PersonReadOnlyRepositoryMock
{
    public readonly Mock<IPersonReadOnlyRepository> Instance;

    public PersonReadOnlyRepositoryMock()
    {
        Instance = new Mock<IPersonReadOnlyRepository>();
    }

    public PersonReadOnlyRepositoryMock SetupSuccessFind(FindPersonsParameters parameters, PersonResponse expected)
    {
        Instance
            .Setup(x => x.FindAsync(parameters))
            .ReturnsAsync(expected);

        return this;
    }
}