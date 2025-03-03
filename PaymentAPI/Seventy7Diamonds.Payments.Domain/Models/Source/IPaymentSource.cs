namespace SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;

public interface IPaymentSource
{
    PaymentSourceType Type { get; }
}