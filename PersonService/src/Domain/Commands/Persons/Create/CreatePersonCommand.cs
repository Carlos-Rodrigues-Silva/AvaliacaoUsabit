using MediatR;

namespace Domain.Commands.Persons.Create;

public class CreatePersonCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Cpf { get; set; }
}