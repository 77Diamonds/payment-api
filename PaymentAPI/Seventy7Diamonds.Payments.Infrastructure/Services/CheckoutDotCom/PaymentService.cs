using Checkout;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Microsoft.Extensions.Options;
using Seventy7Diamonds.Payment.Infrastructure.Extensions;
using Seventy7Diamonds.Payment.Infrastructure.Options;
using SeventySevenDiamonds.Payments.Domain.Interfaces;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using PaymentStatus = SeventySevenDiamonds.Payments.Domain.Models.PaymentStatus;
using PaymentType = Checkout.Payments.PaymentType;
using RequestCardSource = Checkout.Payments.Request.Source.RequestCardSource;

namespace Seventy7Diamonds.Payment.Infrastructure.Services.CheckoutDotCom;

/// <summary>
/// High level abstraction layer to access Checkout.com api
/// </summary>
public class PaymentService : IPaymentService
{
    private readonly CheckoutOptions _options;
    private readonly IPaymentsClient _paymentsApi;

    public PaymentService(IOptions<CheckoutOptions> options)
    {
        _options = options.Value;
        var checkoutApi = CheckoutSdk.Builder().StaticKeys()
            .PublicKey(_options.PublicKey)
            .SecretKey(_options.SecretKey)
            .Environment(Checkout.Environment.Sandbox)
            .Build();
        _paymentsApi = checkoutApi.PaymentsClient();
    }


    public async Task<PaymentRequestResult> SendCardPaymentRequest(CardPaymentRequest request)
    {
        var paymentRequest = request.ToPaymentRequest(_options.ProcessingChannelId);
        var response = await _paymentsApi.RequestPayment(paymentRequest);
        return response.ToPaymentRequestResult();
    }

    public Task<PaymentStatus> GetPaymentStatus(Guid transactionId)
    {
        throw new NotImplementedException();
    }
}