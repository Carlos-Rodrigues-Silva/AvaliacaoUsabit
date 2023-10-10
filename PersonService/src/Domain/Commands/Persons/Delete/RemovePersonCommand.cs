using MediatR;

namespace Domain.Commands.Persons.Delete;

public class RemovePersonCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public RemovePersonCommand(Guid id)
    {
        Id = id;
    }
}