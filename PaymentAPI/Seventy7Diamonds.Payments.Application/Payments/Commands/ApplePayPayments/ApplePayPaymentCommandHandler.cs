using MediatR;
using Seventy7Diamonds.Payment.Infrastructure.Database;
using SeventySevenDiamonds.Payments.Domain.Interfaces;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.ApplePayPayments;

/// <summary>
/// Handle Apple Payment requests
/// </summary>
/// <param name="paymentService"></param>
/// <param name="messagePublisher"></param>
/// <param name="paymentDbContext"></param>
public class ApplePayPaymentCommandHandler(
    IPaymentService paymentService,
    IPublisher messagePublisher,
    PaymentDbContext paymentDbContext) : 
    IRequestHandler<ApplePayPaymentCommand, ApplePayPaymentCommandResult>
{
    public async Task<ApplePayPaymentCommandResult> Handle(ApplePayPaymentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}