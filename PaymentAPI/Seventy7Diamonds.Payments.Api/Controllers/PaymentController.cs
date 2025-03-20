using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Seventy7Diamonds.Payments.Api.Models;
using Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;
using Seventy7Diamonds.Payments.Application.Payments.Queries.GetPaymentStatus;
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

        /// <summary>
        /// Gets the status information of a payment transaction. 
        /// </summary>
        /// <param name="paymentId">The PaymentId returned when the transaction was created</param>
        /// <returns></returns>
        [HttpGet("{paymentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPaymentDetails>> GetPaymentDetails([FromRoute] string paymentId)
        {
            var result = await _mediator.Send(new GetPaymentStatusQuery(){ PaymentId = paymentId});
            return result.Result switch
            {
                GetPaymentStatusQueryResult.Status.NotFound => NotFound(),
                GetPaymentStatusQueryResult.Status.Success => Ok(result.PaymentDetails),
                _ => BadRequest()
            };
        }
    }
}
