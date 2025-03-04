using Checkout.Payments;
using Seventy7Diamonds.Payment.Infrastructure.Services.CheckoutDotCom;
using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using SeventySevenDiamonds.Payments.Domain.Models.Source;
using PaymentType = SeventySevenDiamonds.Payments.Domain.Models.Requests.PaymentType;
using Domain = SeventySevenDiamonds.Payments.Domain.Models;

namespace Seventy7Diamonds.Payments.Infrastructure.Tests;

public class CheckoutPaymentServiceUnitTests
{
    [Fact]
    public async Task SendPaymentRequest_ValidDebitCard_ReturnsSuccess()
    {
        // arrange
        const string expectedResponseSummary = "Approved";
        const bool expectedApprovedStatus = true;
        const string expectedResponseCode = "10000";  // Approved response code
        const Domain.PaymentStatus expectedPaymentStatus = Domain.PaymentStatus.Authorized;
        var expectedReference = $"test_card_payment_{Guid.NewGuid()}";
        var paymentService = new PaymentService();

        var request = new CardPaymentRequest
        {
            Amount = 1024,
            Currency = Currency.EUR,
            PaymentType = PaymentType.Regular,
            Description = expectedReference,
            Reference = expectedReference,
            Source = new CardPaymentSource
            {
                Number = "4659105569051157",
                Cvv = "100",
                ExpiryMonth = 1,
                ExpiryYear = 2026,
                Name = string.Empty,
            }
        };
        
        // act
        var response = await paymentService.SendCardPaymentRequest(request);
        
        // assert
        Assert.NotNull(response);
        Assert.IsType<PaymentRequestResult>(response);
        Assert.Equal(expectedApprovedStatus, response.Approved);
        Assert.Equal(expectedResponseCode, response.ResponseCode);
        Assert.Equal(expectedResponseSummary, response.ResponseSummary);
        Assert.Equal(expectedPaymentStatus, response.Status);
        Assert.Equal(expectedReference, response.Reference);
        Assert.NotNull(response.Id);
        Assert.NotNull(response.ActionId);
    }
}