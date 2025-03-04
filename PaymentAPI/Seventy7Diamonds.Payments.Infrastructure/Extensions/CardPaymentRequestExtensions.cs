using Checkout.Common;
using Checkout.Payments.Request;
using Checkout.Payments.Request.Source;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using PaymentType = Checkout.Payments.PaymentType;

namespace Seventy7Diamonds.Payment.Infrastructure.Extensions;

public static class CardPaymentRequestExtensions
{
    /// <summary>
    /// Maps a Domain's CardPaymentRequest to a Checkout.Payments.Request.PaymentRequest
    /// </summary>
    /// <param name="request"></param>
    /// <param name="processingChannelId">optional for mapping purposes</param>
    /// <returns></returns>
    public static PaymentRequest ToPaymentRequest(this CardPaymentRequest request,
        string? processingChannelId)
    {
        return new PaymentRequest()
        {
            Amount = request.Amount,
            Currency = (Currency?)request.Currency,
            PaymentType = (PaymentType?)request.PaymentType,
            Description = request.Description,
            Reference = request.Reference,
            ProcessingChannelId = processingChannelId,
            Source = new RequestCardSource()
            {
                Number = request.Source.Number,
                Cvv = request.Source.Cvv,
                ExpiryMonth = request.Source.ExpiryMonth,
                ExpiryYear = request.Source.ExpiryYear,
                Name = request.Source.Name
            }
        };
    }
}