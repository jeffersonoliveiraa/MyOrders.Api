using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyOrders.Domain.Commands.v1.Orders.Create;
using MyOrders.Domain.Commands.v1.Orders.Delete;
using MyOrders.Domain.Commands.v1.Orders.Update;
using MyOrders.Domain.Entities.v1;
using MyOrders.Infra.Data.Queries.Queries.v1.GetAll;
using MyOrders.Infra.Data.Queries.Queries.v1.GetById;

namespace MyOrders.Api.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetOrdersAsync()
    {
        try
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery { }));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOrderByIdAsync(int id)
    {
        try
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery { Id = id }));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateOrderAsync([FromBody]Order order)
    {
        try
        {
            return Ok(await _mediator.Send(new CreateOrdersCommand(order.NameShare, order.QuantityShares, order.ShareValue, order.PurchaseDate!)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateOrderAsync([FromBody] Order order)
    {
        try
        {
            return Ok(await _mediator.Send(new UpdateOrdersCommand(order.Id, order.NameShare, order.QuantityShares, order.ShareValue, order.PurchaseDate)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteOrderAsync(int id)
    {
        try
        {
            return Ok(await _mediator.Send(new DeleteOrdersCommand() { Id = id }));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
