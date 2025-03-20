using System.Net;
using MediatR;
using SeventySevenDiamonds.Payments.Domain.Interfaces;

namespace Seventy7Diamonds.Payments.Application.Payments.Queries.GetPaymentSatus;

public class GetPaymentStatusQuery : IRequest<GetPaymentStatusQueryResult>
{
    public required string PaymentId { get; set; }
}

public class GetPaymentStatusQueryHandler(
    IPaymentService paymentService) 
    : IRequestHandler<GetPaymentStatusQuery, GetPaymentStatusQueryResult>
{
    
    public async Task<GetPaymentStatusQueryResult> Handle(GetPaymentStatusQuery request, CancellationToken cancellationToken)
    {
        var response = await paymentService.GetPaymentDetails(request.PaymentId, cancellationToken);
        
        if (response.httpCode == HttpStatusCode.NotFound)
            return GetPaymentStatusQueryResult.NotFound();
        
        return response.data == null 
            ? GetPaymentStatusQueryResult.UnknownError() 
            : GetPaymentStatusQueryResult.Success(response.data);
    }
}