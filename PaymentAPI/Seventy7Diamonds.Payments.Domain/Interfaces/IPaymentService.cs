using SeventySevenDiamonds.Payments.Domain.Models;

namespace SeventySevenDiamonds.Payments.Domain.Interfaces;

public interface IPaymentService
{
    Task<PaymentRequestResult> SendPaymentRequest(PaymentRequest paymentRequest);
    Task<PaymentTransactionStatus> GetPaymentStatus(Guid transactionId);
}