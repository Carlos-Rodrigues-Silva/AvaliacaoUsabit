using Domain.Commands.Persons.Create;
using Domain.Commands.Persons.Delete;
using Domain.Commands.Persons.Update;
using Domain.Queries.Persons.Find;
using Domain.Queries.Persons.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> FindAsync()
    {
        var response = await _mediator.Send(new FindPersonsQuery());

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var response = await _mediator.Send(new GetPersonsByIdQuery(id));

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdatePersonCommand command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePersonCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var response = await _mediator.Send(new RemovePersonCommand(id));

        return Ok(response);
    }
}
