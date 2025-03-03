using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;
using SeventySevenDiamonds.Payments.Domain.Models.Source;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;

public class CardPaymentRequest : AbstractPaymentRequest
{
    public new required CardPaymentSource Source { get; set; }
}