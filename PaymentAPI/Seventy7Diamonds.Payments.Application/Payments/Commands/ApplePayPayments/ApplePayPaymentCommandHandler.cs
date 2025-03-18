using MediatR;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.ApplePayPayments;

public class ApplePayPaymentCommandHandler : 
    IRequestHandler<ApplePayPaymentCommand, ApplePayPaymentCommandResult>
{
    public Task<ApplePayPaymentCommandResult> Handle(ApplePayPaymentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}