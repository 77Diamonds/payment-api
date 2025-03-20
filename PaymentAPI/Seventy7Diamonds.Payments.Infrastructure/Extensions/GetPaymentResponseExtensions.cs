using Checkout.Payments.Response;
using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payment.Infrastructure.Extensions;

public static class GetPaymentResponseExtensions
{
    public static GetPaymentDetails ToGetPaymentDetails(this GetPaymentResponse response)
    {
        return new GetPaymentDetails()
        {
            Id = response.Id,
            SchemeId = response.SchemeId,
            RequestedOn = response.RequestedOn,
            ProcessedOn = response.ProcessedOn,
            Amount = response.Amount,
            AmountRequested = response.AmountRequested,
            Currency = response.Currency.ToString(),
            PaymentType = response.PaymentType.ToString(),
            Reference = response.Reference,
            Description = response.Description, 
            Approved = response.Approved,
            ExpiresOn = response.ExpiresOn,
            Status = response.Status.ToString(),
        };
    }
}