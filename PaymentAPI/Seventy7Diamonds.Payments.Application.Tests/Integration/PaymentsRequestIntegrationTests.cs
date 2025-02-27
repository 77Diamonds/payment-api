using System.Diagnostics;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Payments.Request.Source; 
using Checkout.Payments.Response;
using Xunit.Abstractions;

namespace Seventy7Diamonds.Payments.Application.Tests.Integration;

public class PaymentsRequestIntegrationTests 
{
    private readonly CheckoutApiSandboxFixture _apiSandboxFixture;
    private readonly IPaymentsClient _paymentsApi;
    public PaymentsRequestIntegrationTests()      
    {
        _apiSandboxFixture = new CheckoutApiSandboxFixture();
        _paymentsApi = _apiSandboxFixture.CheckoutApi.PaymentsClient();
    }
    
    /// <summary>
    /// Test cards based on table available at
    /// https://www.checkout.com/docs/developer-resources/testing/test-cards
    /// </summary>
    private readonly RequestCardSource _validVisaDebitCardSource = new RequestCardSource()
    {
        Number = "4659105569051157",
        Cvv = "100",
        ExpiryMonth = 1,
        ExpiryYear = 2026
    };

    [Fact]
    public async Task PostPaymentRequest_ValidVisaDebitCard_ReturnsSuccess()
    {
        // arrange
        const int expectedHttpStatusCode = 201;
        const string expectedResponseSummary = "Approved";
        const bool expectedRiskFlagged = false;
        const bool expectedApprovedStatus = true;
        const string expectedResponseCode = "10000";  // Approved response code
        const PaymentStatus expectedPaymentStatus = PaymentStatus.Authorized;

        var request = new PaymentRequest()
        {
            Amount = 1024,
            Currency = Currency.EUR,
            PaymentType = PaymentType.Regular,
            Description = "Test Payment via SDK",
            Reference = "Test Payment with valid VISA",
            Source = _validVisaDebitCardSource,
            ProcessingChannelId = CheckoutApiSandboxFixture.ProcessingChannelId
        };
        
        // act
        var response = await _paymentsApi.RequestPayment(request);

        // assert
        Assert.NotNull(response);
        Assert.IsType<PaymentResponse>(response);
        Assert.Equal(expectedHttpStatusCode, response.HttpStatusCode);
        Assert.Equal(expectedApprovedStatus, response.Approved);
        Assert.Equal(expectedResponseCode, response.ResponseCode);
        Assert.Equal(expectedResponseSummary, response.ResponseSummary);
        Assert.Equal(expectedRiskFlagged, response.Risk.Flagged);
        Assert.Equal(expectedPaymentStatus, response.Status);
    }
    
    [Fact]
    public async Task PostPaymentRequest_ExpiredVisaDebitCard_ReturnsError()
    {
        // arrange
        const int expectedHttpStatusCode = 201;
        const string expectedResponseSummary = "No security model";
        const bool expectedRiskFlagged = false;
        const bool expectedApprovedStatus = false;
        const string expectedResponseCode = "20082";  // Declined response code
        const PaymentStatus expectedPaymentStatus = PaymentStatus.Declined;

        var request = new PaymentRequest()
        {
            Amount = 8105,
            Currency = Currency.EUR,
            PaymentType = PaymentType.Regular,
            Description = "Test Payment via SDK",
            Reference = "Test Payment with valid but expired VISA",
            Source = _validVisaDebitCardSource,
            ProcessingChannelId = CheckoutApiSandboxFixture.ProcessingChannelId
        };
        
        // act
        var response = await _paymentsApi.RequestPayment(request);

        // assert
        Assert.NotNull(response);
        Assert.IsType<PaymentResponse>(response);
        Assert.Equal(expectedHttpStatusCode, response.HttpStatusCode);
        Assert.Equal(expectedApprovedStatus, response.Approved);
        Assert.Equal(expectedResponseCode, response.ResponseCode);
        Assert.Equal(expectedResponseSummary, response.ResponseSummary);
        Assert.Equal(expectedRiskFlagged, response.Risk.Flagged);
        Assert.Equal(expectedPaymentStatus, response.Status);
    }
}
