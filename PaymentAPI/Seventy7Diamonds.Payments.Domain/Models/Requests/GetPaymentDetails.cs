using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.PaymentSource;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;

public class GetPaymentDetails
{
    public string Id { get; set; }
    
    public string SchemeId { get; set; }

    public DateTime? RequestedOn { get; set; }

    public string ProcessedOn { get; set; }
    
    public long? Amount { get; set; }

    public long? AmountRequested { get; set; }
    
    public Currency? Currency { get; set; }
    
    public PaymentSourceType? PaymentType { get; set; }
    
    public string Reference { get; set; }

    public string Description { get; set; }

    public bool? Approved { get; set; }

    public DateTime? ExpiresOn { get; set; }

    public PaymentStatus? Status { get; set; }
    
}