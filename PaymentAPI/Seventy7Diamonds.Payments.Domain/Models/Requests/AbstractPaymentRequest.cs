using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;


public abstract class AbstractPaymentRequest
{
    public long? Amount { get; set; }
 
    public required Currency Currency{ get; set; }

    public PaymentType? PaymentType { get; set; }
    
    public required string Description { get; set; }
    
    public required string Reference { get; set; }
    
    public IPaymentSource? Source { get; set; }
    
}


