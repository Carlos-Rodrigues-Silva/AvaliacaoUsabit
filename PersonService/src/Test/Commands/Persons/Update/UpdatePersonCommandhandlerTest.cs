using AutoFixture;
using AutoMapper;
using Domain.Commands.Persons.Update;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Mappers;
using MassTransit;
using MediatR;
using Moq;
using Xunit;

namespace Test.Commands.Persons.Update;

public class UpdatePersonCommandhandlerTest
{
    private readonly IMapper _mapper;

    public UpdatePersonCommandhandlerTest()
    {
        _mapper = new MapperConfiguration(options => options.AddProfile<PersonProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidData_ReturnsUnitValue()
    {
        var repository = new Mock<IPersonRepository>();
        var _personReadOnlyRepository = new Mock<IPersonReadOnlyRepository>();
        var publishEndpoint = new Mock<IPublishEndpoint>();

        var request = new Fixture().Create<UpdatePersonCommand>();
        var handler = new UpdatePersonCommandhandler(
            repository.Object,
            _personReadOnlyRepository.Object,
            publishEndpoint.Object,
            _mapper);

        var response = await handler.Handle(request, default);

        Assert.Equal(Unit.Value, response);

        repository.Verify(x => x.UpdateAsync(It.IsAny<Person>()), Times.Once);
    }
}