using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SeventySevenDiamonds.Payments.Domain.Interfaces;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;

public class CardPaymentCommandHandler(
    IPaymentService paymentService,
    IMapper mapper)
    : IRequestHandler<CardPaymentCommand, CardPaymentCommandResult>
{
    
    public async Task<CardPaymentCommandResult> Handle(CardPaymentCommand command, CancellationToken cancellationToken)
    {
        var request = mapper.Map<CardPaymentRequest>(command); 
        var response = await paymentService.SendCardPaymentRequest(request);
        
        var result = mapper.Map<CardPaymentCommandResult>(response);
        return result;
    }
}