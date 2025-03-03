using SeventySevenDiamonds.Payments.Domain.Models;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace SeventySevenDiamonds.Payments.Domain.Interfaces;

public interface IPaymentService
{
    Task<PaymentRequestResult> SendPaymentRequest(AbstractPaymentRequest abstractPaymentRequest);
    Task<PaymentTransactionStatus> GetPaymentStatus(Guid transactionId);
}