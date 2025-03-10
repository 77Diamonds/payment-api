using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;

public record CardPaymentCommandResult
{
    public required string Id { get; set; }

    public PaymentType? PaymentType { get; set; }

    public required string ActionId { get; set; }

    public long? Amount { get; set; }

    public long? AmountRequested { get; set; }

    public string Currency { get; set; }

    public bool? Approved { get; set; }

    public PaymentStatus? Status { get; set; }

    public required string AuthCode { get; set; }

    public required string ResponseCode { get; set; }
    
}