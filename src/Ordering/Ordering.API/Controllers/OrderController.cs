using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Handlers;
using Ordering.Application.Queries;
using Ordering.Application.Responses;

namespace Ordering.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrderByUserName(string userName)
        {
            var query = new GetOrderByUserNameQuery(userName);
            var orders = await mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> CheckoutOrder([FromBody]CheckoutOrderCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}