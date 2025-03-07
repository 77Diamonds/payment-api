using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Seventy7Diamonds.Payments.Application.Payments.Commands.Extensions;
using SeventySevenDiamonds.Payments.Domain.Events;
using SeventySevenDiamonds.Payments.Domain.Interfaces;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;

public class CardPaymentCommandHandler(
    IPaymentService paymentService,
    IPublisher messagePublisher,
    IMapper mapper)
    : IRequestHandler<CardPaymentCommand, CardPaymentCommandResult>
{
    
    public async Task<CardPaymentCommandResult> Handle(CardPaymentCommand command, CancellationToken cancellationToken)
    {
        var request = command.ToRequest(); 
        var response = await paymentService.SendCardPaymentRequest(request, CancellationToken.None);
        await messagePublisher.Publish(new CardPaymentRequestSentEvent(
            DateTimeOffset.UtcNow, 
            request), cancellationToken);        
        
        var result = mapper.Map<CardPaymentCommandResult>(response);
        return result;
    }
}