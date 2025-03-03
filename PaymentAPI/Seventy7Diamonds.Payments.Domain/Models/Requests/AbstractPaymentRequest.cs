using SeventySevenDiamonds.Payments.Domain.Models.Common;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;


public abstract class AbstractPaymentRequest
{
    public long? Amount { get; set; }
 
    public required Currency Currency{ get; set; }

    public PaymentType? PaymentType { get; set; }
    
    public required string Description { get; set; }
    
    public required string Reference { get; set; }
    
}


