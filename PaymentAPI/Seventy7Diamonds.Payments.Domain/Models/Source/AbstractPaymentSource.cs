using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;

namespace SeventySevenDiamonds.Payments.Domain.Models.Source;

public abstract class AbstractPaymentSource
{
    PaymentSourceType Type { get; }
}