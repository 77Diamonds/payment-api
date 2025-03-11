using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Seventy7Diamonds.Payments.Api.Models;
using Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;
using Seventy7Diamonds.Payments.Application.Payments.Queries.CardPayments;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Api.Controllers
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;    
        }

        [HttpPost]
        public async Task<IActionResult> PostCardPaymentCommand(CardPaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet, Route("{PaymentId}")]
        public async Task<IActionResult> GetPaymentDetails([FromRoute] string paymentId)
        {
            var result = await _mediator.Send(new GetPaymentStatusQuery(){ PaymentId = paymentId});
            throw new NotImplementedException();
        }
    }
}
