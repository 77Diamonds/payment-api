using SeventySevenDiamonds.Payments.Domain.Models.Source;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;

public class CardPaymentRequest : PaymentRequest<CardPaymentSource>
{
    public CardPaymentRequest() {}
}