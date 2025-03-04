using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;

namespace SeventySevenDiamonds.Payments.Domain.Models.Source;

public class CardPaymentSource : AbstractPaymentSource
{
    public PaymentSourceType Type  => PaymentSourceType.Card;   
    
    public required string Number { get; set; }

    public int? ExpiryMonth { get; set; }

    public int? ExpiryYear { get; set; }

    public required string Name { get; set; }

    public required string Cvv { get; set; }
    
    public Address? BillingAddress { get; set; }

    public Phone? Phone { get; set; }
}