using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Application.Payments.Queries.GetPaymentStatus;

public record GetPaymentStatusQueryResult
{

    public GetPaymentStatusQueryResult(
        Status result,
        GetPaymentDetails? paymentDetails)
    {
        Result = result;
        PaymentDetails = paymentDetails;
    }
    
    public Status Result { get; set; }
    public GetPaymentDetails? PaymentDetails { get; set; }

    public enum Status
    {
        Success,
        NotFound,
        UnknownError,
    }

    #region "Static Contructors for all Status values"
    public static GetPaymentStatusQueryResult NotFound()
    {
        return new GetPaymentStatusQueryResult(Status.NotFound, null);
    }
    public static GetPaymentStatusQueryResult Success(GetPaymentDetails paymentDetails)
    {
        return new GetPaymentStatusQueryResult(Status.Success, paymentDetails);
    }
    public static GetPaymentStatusQueryResult UnknownError()
    {
        return new GetPaymentStatusQueryResult(Status.UnknownError, null);
    }
    
    #endregion
    
}