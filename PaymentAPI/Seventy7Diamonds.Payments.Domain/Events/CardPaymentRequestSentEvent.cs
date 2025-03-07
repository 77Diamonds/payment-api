using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace SeventySevenDiamonds.Payments.Domain.Events;


public class CardPaymentRequestSentEvent(DateTimeOffset eventDate, CardPaymentRequest request)
{
    public DateTimeOffset EventDate = eventDate;

    public CardPaymentRequest Request = request;
}