using Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.Extensions;

public static class CardPaymentCommandExtensions
{
    public static CardPaymentRequest ToRequest(this CardPaymentCommand  command)
    {
        return new CardPaymentRequest()
        {
            Currency = command.Currency,
            Amount = command.Amount,
            Description = command.Description,
            Reference = command.Reference,
            PaymentType = command.PaymentType,
            Source = command.Card
        };
    } 
}