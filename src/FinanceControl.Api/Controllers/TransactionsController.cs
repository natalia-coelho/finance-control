using Microsoft.AspNetCore.Mvc;
using MediatR;
using FinanceControl.Application.Commands;
using FinanceControl.Application.Queries;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
        var query = new GetTransactionsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> AddTransaction([FromBody] AddTransactionCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTransactions), new { id = result.Id }, result);
    }
}
