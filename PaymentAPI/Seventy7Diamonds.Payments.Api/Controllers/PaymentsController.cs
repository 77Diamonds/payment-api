using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seventy7Diamonds.Payments.Api.Models;

namespace Seventy7Diamonds.Payments.Api.Controllers
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;    
        }
    }
}
