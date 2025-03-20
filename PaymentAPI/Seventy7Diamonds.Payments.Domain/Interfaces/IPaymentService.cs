using System.Net;
using SeventySevenDiamonds.Payments.Domain.Models;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using SeventySevenDiamonds.Payments.Domain.Models.Source;

namespace SeventySevenDiamonds.Payments.Domain.Interfaces;

public interface IPaymentService
{
    Task<PaymentRequestResult> SendCardPaymentRequest(CardPaymentRequest request, CancellationToken cancellationToken);
    
    
    Task<(HttpStatusCode httpCode,GetPaymentDetails? data)> GetPaymentDetails(string paymentId, CancellationToken cancellationToken);
}