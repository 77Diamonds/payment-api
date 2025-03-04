using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;
using SeventySevenDiamonds.Payments.Domain.Models.Source;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;


public abstract class PaymentRequest<TPaymentSource> 
    where TPaymentSource : AbstractPaymentSource
{
    public long? Amount { get; set; }
 
    public required Currency Currency{ get; set; }

    public PaymentType? PaymentType { get; set; }
    
    public required string Description { get; set; }
    
    public required string Reference { get; set; }
    
    public required TPaymentSource Source { get; set; }
    
}


