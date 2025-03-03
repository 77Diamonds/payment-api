using AutoMapper;
using MediatR;
using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using SeventySevenDiamonds.Payments.Domain.Models.Source;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;

public class CardPaymentCommand : IRequest<CardPaymentCommandResult> 
{
    public long? Amount { get; set; }
 
    public required Currency Currency{ get; set; }

    public PaymentType? PaymentType { get; set; }
    
    public required string Description { get; set; }
    
    public required string Reference { get; set; }
    
    public CardPaymentSource Card { get; set; }

    /*
    /// <summary>
    /// Maps from CardPaymentSource domain object
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CardPaymentCommand, CardPaymentRequest>()
            .ForMember()
    }
    */
}

