using SeventySevenDiamonds.Payments.Domain.Models.Common;

namespace SeventySevenDiamonds.Payments.Domain.Models.Requests;

public class PaymentRequestResult
{
    public required string Id { get; set; }

    public PaymentType? PaymentType { get; set; }

    public required string ActionId { get; set; }

    public long? Amount { get; set; }

    public long? AmountRequested { get; set; }

    public Currency? Currency { get; set; }

    public bool? Approved { get; set; }

    public PaymentStatus? Status { get; set; }

    public required string AuthCode { get; set; }

    public required string ResponseCode { get; set; }

    public required string ResponseSummary { get; set; }

    public DateTime? ExpiresOn { get; set; }
    
    public string? Reference { get; set; }
    
    /*
    public RiskAssessment Risk { get; set; }

    [JsonConverter(typeof (PaymentResponseSourceTypeConverter))]
    public IResponseSource Source { get; set; }

    public CustomerResponse Customer { get; set; }

    public PaymentResponseBalances Balances { get; set; }
    */

    public DateTime? ProcessedOn { get; set; }    

    /*
    public PaymentProcessing Processing { get; set; }

    public string Eci { get; set; }

    public string SchemeId { get; set; }

    public PaymentRetryResponse Retry { get; set; }
    */
}