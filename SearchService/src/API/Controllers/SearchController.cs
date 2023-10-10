using Domain.Parameters;
using Domain.Queries.Persons.Find;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly IMediator _mediator;

    public SearchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> SearchPersons([FromQuery] FindPersonsParameters parameters)
    {
        var response = await _mediator.Send(new FindPersonsQuery(parameters));

        return Ok(response);
    }
}