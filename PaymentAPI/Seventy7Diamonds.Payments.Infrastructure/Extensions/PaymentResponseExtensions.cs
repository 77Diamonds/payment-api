using Checkout.Payments.Response;
using SeventySevenDiamonds.Payments.Domain.Models;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using Domain = SeventySevenDiamonds.Payments.Domain.Models;

namespace Seventy7Diamonds.Payment.Infrastructure.Extensions;

public static class PaymentResponseExtensions
{
    /// <summary>
    /// Maps a Domain's Checkout.Payments.Response.PaymentResponse to a domain's PaymentRequestResult
    /// </summary>
    /// <param name="paymentResponse"></param>
    /// <returns></returns>
    public static PaymentRequestResult ToPaymentRequestResult(this PaymentResponse paymentResponse)
    {
        return new PaymentRequestResult()
        {
            Id = paymentResponse.Id,
            ActionId = paymentResponse.ActionId,
            Amount = paymentResponse.Amount,
            Approved = paymentResponse.Approved,
            Currency = (Domain.Common.Currency?)paymentResponse.Currency,
            PaymentType = (Domain.Requests.PaymentType?)paymentResponse.PaymentType,
            AuthCode = paymentResponse.AuthCode,
            ResponseCode = paymentResponse.ResponseCode,
            ResponseSummary = paymentResponse.ResponseSummary,
            Status = (PaymentStatus?)paymentResponse.Status,
            AmountRequested = paymentResponse.AmountRequested,
            ExpiresOn = paymentResponse.ExpiresOn,
            Reference = paymentResponse.Reference
        };
    }
}