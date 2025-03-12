using MediatR;
using Seventy7Diamonds.Payment.Infrastructure.Database;
using Seventy7Diamonds.Payments.Application.Payments.Commands.Extensions;
using SeventySevenDiamonds.Payments.Domain.Events;
using SeventySevenDiamonds.Payments.Domain.Interfaces;
using System.Text.Json;

namespace Seventy7Diamonds.Payments.Application.Payments.Commands.CardPayments;

public class CardPaymentCommandHandler(
    IPaymentService paymentService,
    IPublisher messagePublisher,
    PaymentDbContext paymentDbContext)
    : IRequestHandler<CardPaymentCommand, CardPaymentCommandResult>
{

    public async Task<CardPaymentCommandResult> Handle(CardPaymentCommand command, CancellationToken cancellationToken)
    {
        var request = command.ToRequest();

        var response = await paymentService.SendCardPaymentRequest(request, CancellationToken.None);
        
        // save communication to the database
        await paymentDbContext.Payments.AddAsync(new SeventySevenDiamonds.Payments.Domain.Entities.Payment()
        {
            Id = Guid.Parse(response.Id),
            CreatedOn = DateTimeOffset.UtcNow,
            Request = JsonSerializer.Serialize(request),
            Response = JsonSerializer.Serialize(response)
        }, cancellationToken);
        
        // notify other systems
        await messagePublisher.Publish(new CardPaymentRequestSentEvent(
            DateTimeOffset.UtcNow,
            request), cancellationToken);

        return response.ToCardPaymentCommandResult();
    }

}