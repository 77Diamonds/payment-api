using System.Runtime.CompilerServices;
using Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.Extensions;

public static class PaymentRequestResultExtensions
{
    public static CardPaymentCommandResult ToCardPaymentCommandResult(this PaymentRequestResult request)
    {
        return new CardPaymentCommandResult()
        {
            Id = request.Id,
            PaymentType =  request.PaymentType,
            ActionId = request.ActionId,
            Amount = request.Amount,
            AmountRequested =  request.AmountRequested,
            Currency = request.Currency.ToString() ?? string.Empty,
            Approved = request.Approved,
            Status =  request.Status,
            AuthCode = request.AuthCode,
            ResponseCode = request.ResponseCode,
        };
    }
}