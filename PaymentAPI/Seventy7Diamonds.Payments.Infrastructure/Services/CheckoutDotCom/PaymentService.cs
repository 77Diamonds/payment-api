using Checkout;
using Microsoft.Extensions.Logging;
using SeventySevenDiamonds.Payments.Domain.Interfaces;
using SeventySevenDiamonds.Payments.Domain.Models;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payment.Infrastructure.Services.CheckoutDotCom;

/// <summary>
/// High level abstraction layer to access Checkout.com api
/// </summary>
public class PaymentService(ICheckoutApi checkoutApi, ILogger<PaymentService> logger) : IPaymentService
{

    public Task<PaymentRequestResult> SendPaymentRequest(AbstractPaymentRequest abstractPaymentRequest)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentTransactionStatus> GetPaymentStatus(Guid transactionId)
    {
        throw new NotImplementedException();
    }
}