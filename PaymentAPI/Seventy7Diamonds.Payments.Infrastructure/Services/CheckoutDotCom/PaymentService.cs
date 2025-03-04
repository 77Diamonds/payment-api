using Checkout;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Previous.Request.Source;
using Checkout.Payments.Request;
using Microsoft.Extensions.Logging;
using SeventySevenDiamonds.Payments.Domain.Interfaces;
using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using SeventySevenDiamonds.Payments.Domain.Models.Source;
using Environment = System.Environment;
using PaymentSourceType = SeventySevenDiamonds.Payments.Domain.Models.PaymentSource.PaymentSourceType;
using PaymentStatus = SeventySevenDiamonds.Payments.Domain.Models.PaymentStatus;
using PaymentType = Checkout.Payments.PaymentType;
using RequestCardSource = Checkout.Payments.Request.Source.RequestCardSource;

namespace Seventy7Diamonds.Payment.Infrastructure.Services.CheckoutDotCom;

/// <summary>
/// High level abstraction layer to access Checkout.com api
/// </summary>
public class PaymentService : IPaymentService
{
    private const string PublicKey = "pk_sbox_szo5m4izt7xqr5g7uvc3j6wolit";
    private const string SecretKey = "sk_sbox_vzsdl6tauei3bdkxftatbunr5al";
    private const string ProcessingChannelId = "pc_d7u3ecyxckteldjo4a33dbqfby";
    
    // TODO: get checkout environment from config
    private readonly ICheckoutApi _checkoutApi;
    private readonly IPaymentsClient _paymentsApi;

    public PaymentService()
    {
        _checkoutApi = CheckoutSdk.Builder().StaticKeys()
            .PublicKey(PublicKey)
            .SecretKey(SecretKey)
            .Environment(Checkout.Environment.Sandbox)
            .Build();
        _paymentsApi = _checkoutApi.PaymentsClient();
    }


    public async Task<PaymentRequestResult> SendCardPaymentRequest(PaymentRequest<CardPaymentSource> paymentRequest)
    {
        var request = new PaymentRequest()
        {
            Amount = paymentRequest.Amount,
            Currency = (Currency?)paymentRequest.Currency,
            PaymentType = (PaymentType?)paymentRequest.PaymentType,
            Description = paymentRequest.Description,
            Reference = paymentRequest.Reference,
            ProcessingChannelId = ProcessingChannelId,
            Source = new RequestCardSource()
            {
                Number = paymentRequest.Source.Number,
                Cvv = paymentRequest.Source.Cvv,
                ExpiryMonth = paymentRequest.Source.ExpiryMonth,
                ExpiryYear = paymentRequest.Source.ExpiryYear,
                Name = paymentRequest.Source.Name
            }
        };

        var response = await _paymentsApi.RequestPayment(request);
        
        return new PaymentRequestResult()
        {
            Id = response.Id,
            ActionId = response.ActionId,
            Amount = response.Amount,
            Approved = response.Approved,
            Currency = (SeventySevenDiamonds.Payments.Domain.Models.Common.Currency?)response.Currency,
            PaymentType = (SeventySevenDiamonds.Payments.Domain.Models.Requests.PaymentType?)response.PaymentType,
            AuthCode = response.AuthCode,
            ResponseCode = response.ResponseCode,
            ResponseSummary = response.ResponseSummary,
            Status = (PaymentStatus?)response.Status,
            AmountRequested = response.AmountRequested,
            ExpiresOn = response.ExpiresOn,
            Reference = response.Reference,
        };
    }

    public Task<PaymentStatus> GetPaymentStatus(Guid transactionId)
    {
        throw new NotImplementedException();
    }
}