using MediatR;
using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.ApplePayPayments;

public class ApplePayPaymentCommand : IRequest<ApplePayPaymentCommandResult>
{
    public long? Amount { get; set; }
 
    public required Currency Currency{ get; set; }

    public PaymentType? PaymentType { get; set; }
    
    public required string Description { get; set; }
    
    public required string Reference { get; set; }
    
    public required ApplePayPaymentSource ApplePay { get; set; }

}