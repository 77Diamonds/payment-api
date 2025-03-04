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

/// <summary>
/// Unit tests fot Checkout Payment Services.
/// Test cards based on table available at
/// https://www.checkout.com/docs/developer-resources/testing/test-cards
/// </summary>
public class CheckoutPaymentServiceShould
{
    private readonly Mock<IOptions<CheckoutOptions>> _mockOptions = new Mock<IOptions<CheckoutOptions>>();
    
    public CheckoutPaymentServiceShould()
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
    public async Task Return_success_when_valid_card_used_in_payment_request()
    {
        // arrange
        const string expectedResponseSummary = "Approved";
        const bool expectedApprovedStatus = true;
        const string expectedResponseCode = "10000";  // Approved response code
        const PaymentStatus expectedPaymentStatus = PaymentStatus.Authorized;
        var expectedReference = $"test_valid_card_payment_{Guid.NewGuid()}";
        
        var paymentService = new PaymentService(_mockOptions.Object);
        var request = new CardPaymentRequest
        {
            Amount = 10024,
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
        var response = await paymentService.SendCardPaymentRequest(request, CancellationToken.None);
        
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

    
    [Fact]
    public async Task Return_error_when_expired_card_used_in_payment_request()
    {
        // arrange
        const bool expectedApprovedStatus = false;
        const string expectedResponseSummary = "No security model";
        const string expectedResponseCode = "20082";  // Declined response code
        const PaymentStatus expectedPaymentStatus = PaymentStatus.Declined;
        var expectedReference = $"test_expired_card_payment_{Guid.NewGuid()}";

        var paymentService = new PaymentService(_mockOptions.Object);
        var request = new CardPaymentRequest()
        {
            Amount = 8105,
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
        var response = await paymentService.SendCardPaymentRequest(request, CancellationToken.None);

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
    
    [Fact]
    public async Task Return_error_when_invalid_card_used_in_payment_request()
    {
        // arrange
        const bool expectedApprovedStatus = false;
        const string expectedResponseSummary = "Invalid Card Number";
        const string expectedResponseCode = "20014"; 
        const PaymentStatus expectedPaymentStatus = PaymentStatus.Declined;
        var expectedReference = $"test_invalid_card_payment_{Guid.NewGuid()}";

        var paymentService = new PaymentService(_mockOptions.Object);
        var request = new CardPaymentRequest()
        {
            Amount = 8105,
            Currency = Currency.EUR,
            PaymentType = PaymentType.Regular,
            Description = expectedReference,
            Reference = expectedReference,
            Source = new CardPaymentSource
            {
                Number = "4485381577182090",
                Cvv = "100",
                ExpiryMonth = 1,
                ExpiryYear = 2026,
                Name = string.Empty,
            }
        };
        
        // act
        var response = await paymentService.SendCardPaymentRequest(request, CancellationToken.None);

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

    [Fact]
    public async Task Return_success_when_getting_valid_transaction_details()
    {
        // arrange
        var paymentService = new PaymentService(_mockOptions.Object);
        var request = new CardPaymentRequest()
        {
            Amount = 8105,
            Currency = Currency.EUR,
            PaymentType = PaymentType.Regular,
            Description = "",
            Reference = "",
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
        var response = await paymentService.SendCardPaymentRequest(request, CancellationToken.None);
        var details = await paymentService.GetPaymentDetails(response.Id, CancellationToken.None);
        
        // assert
        Assert.NotNull(details);
        Assert.Equal(response.Id, details.Id);
        Assert.Equal(response.Status, details.Status);

    }
}