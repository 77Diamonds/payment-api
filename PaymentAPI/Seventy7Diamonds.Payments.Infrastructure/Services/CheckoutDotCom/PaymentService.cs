using System.Net;
using Checkout;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Payments.Request.Source;
using Microsoft.Extensions.Options;
using Seventy7Diamonds.Payment.Infrastructure.Extensions;
using Seventy7Diamonds.Payment.Infrastructure.Options;
using SeventySevenDiamonds.Payments.Domain.Interfaces;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

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

    public async Task<PaymentRequestResult> SendCardPaymentRequest(CardPaymentRequest request, 
        CancellationToken cancellationToken)
    {
        var paymentRequest = request.ToPaymentRequest(_options.ProcessingChannelId);
        var response = await _paymentsApi.RequestPayment(paymentRequest, null, cancellationToken);
        return response.ToPaymentRequestResult();
    }

    public async Task<(HttpStatusCode httpCode,GetPaymentDetails? data)> GetPaymentDetails(string paymentId, 
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _paymentsApi.GetPaymentDetails(paymentId, cancellationToken);
            return ((HttpStatusCode)response.HttpStatusCode!, response.ToGetPaymentDetails());
        }
        catch (CheckoutApiException ex)
        {
            return (ex.HttpStatusCode, null);
        }
    }
}