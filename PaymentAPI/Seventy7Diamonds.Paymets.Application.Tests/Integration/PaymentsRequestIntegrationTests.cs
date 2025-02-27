using Checkout;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Payments.Request.Source;
using Checkout.Payments.Response;
using Checkout.Sessions;

namespace Seventy7Diamonds.Paymets.Application.Tests;

public class PaymentsRequestIntegrationTests
{
    private readonly string _clientID = "ack_usg74gyctmau3lzxmpm4lvuhju";
    private readonly string _publicKey = "pk_sbox_g3iid7ew7clcwgyjn63gxhlc4mj";
    private readonly string _secretKey = "sk_sbox_vbgt3aucy7xnj7kftnrhxjmhpm2";
    private readonly string _processingChannelId = "pc_7b4tpe676mue3bao5nvj5ovzem";
    private readonly string _authURI = "https://access.sandbox.checkout.com/connect/token";

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
        const string expectedResponseCode = "10000";  // Approved response code
        const PaymentStatus expectedPaymentStatus = PaymentStatus.Authorized;

        var api = CheckoutSdk.Builder().StaticKeys()
            .PublicKey(_publicKey)
            .SecretKey(_secretKey)
            .Environment(Checkout.Environment.Sandbox)
            .Build();

        var paymentsApi = api.PaymentsClient();
        var request = new PaymentRequest()
        {
            Amount = 1024,
            Currency = Currency.EUR,
            PaymentType = PaymentType.Regular,
            Description = "Test Payment via SDK",
            Reference = "Test Payment with valid VISA",
            Source = _validVisaDebitCardSource,
            ProcessingChannelId = _processingChannelId
        };
        
        // act
        var response = await paymentsApi.RequestPayment(request);

        // assert
        Assert.NotNull(response);
        Assert.IsType<PaymentResponse>(response);
        Assert.Equal(expectedHttpStatusCode, response.HttpStatusCode);
        Assert.Equal(expectedResponseCode, response.ResponseCode);
        Assert.Equal(expectedResponseSummary, response.ResponseSummary);
        Assert.Equal(expectedRiskFlagged, response.Risk.Flagged);
        Assert.Equal(expectedPaymentStatus, response.Status);
    }
}
