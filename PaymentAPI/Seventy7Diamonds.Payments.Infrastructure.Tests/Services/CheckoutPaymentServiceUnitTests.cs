using Microsoft.Extensions.Options;
using Moq;
using Seventy7Diamonds.Payment.Infrastructure.Options;
using Seventy7Diamonds.Payment.Infrastructure.Services.CheckoutDotCom;
using SeventySevenDiamonds.Payments.Domain.Models.Common;
using SeventySevenDiamonds.Payments.Domain.Models.Requests;
using SeventySevenDiamonds.Payments.Domain.Models.Source;
using PaymentType = SeventySevenDiamonds.Payments.Domain.Models.Requests.PaymentType;
using Domain = SeventySevenDiamonds.Payments.Domain.Models;

namespace Seventy7Diamonds.Payments.Infrastructure.Tests.Services;

public class CheckoutPaymentServiceUnitTests
{
    private readonly Mock<IOptions<CheckoutOptions>> _mockOptions = new Mock<IOptions<CheckoutOptions>>();
    
    public CheckoutPaymentServiceUnitTests()
    {
        var checkoutOptions = new CheckoutOptions()
        {
            PublicKey = "pk_sbox_szo5m4izt7xqr5g7uvc3j6wolit",
            SecretKey = "sk_sbox_vzsdl6tauei3bdkxftatbunr5al",
            ProcessingChannelId = "pc_d7u3ecyxckteldjo4a33dbqfby",
            Environment = Checkout.Environment.Sandbox
        };
        
        _mockOptions.Setup(x => x.Value).Returns(checkoutOptions);
    }
    
    [Fact]
    public async Task SendPaymentRequest_ValidDebitCard_ReturnsSuccess()
    {
        // arrange
        const string expectedResponseSummary = "Approved";
        const bool expectedApprovedStatus = true;
        const string expectedResponseCode = "10000";  // Approved response code
        const Domain.PaymentStatus expectedPaymentStatus = Domain.PaymentStatus.Authorized;
        
        var expectedReference = $"test_card_payment_{Guid.NewGuid()}";
        var paymentService = new PaymentService(_mockOptions.Object);
        
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