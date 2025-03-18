using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;
using SeventySevenDiamonds.Payments.Domain.Models.Source;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;

/// <summary>
/// Token payment source to be used by Apple Pay 
/// </summary>
public class ApplePayPaymentSource : AbstractPaymentSource
{
    public PaymentSourceType Type  => PaymentSourceType.Token;   
    
    /// <summary>
    /// Apple Pay generated token.
    /// It must be generated on client site and informed on request
    /// </summary>
    public required string Token { get; set; }

    public Address? BillingAddress { get; set; }

    public Phone? Phone { get; set; }

    public bool? Stored { get; set; }

    public bool? StoreForFutureUse { get; set; }
    
}