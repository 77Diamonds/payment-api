using MediatR;

namespace Seventy7Diamonds.Payments.Application.Payments.Queries.GetPaymentSatus;

public class GetPaymentStatusQuery : IRequest<GetPaymentStatusQueryResult>
{
    public required string PaymentId { get; set; }
}

public enum GetPaymentStatusQueryResult {}


public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusQuery, GetPaymentStatusQueryResult>
{
    public Task<GetPaymentStatusQueryResult> Handle(GetPaymentStatusQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}