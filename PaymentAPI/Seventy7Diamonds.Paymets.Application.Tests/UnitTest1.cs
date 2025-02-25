using Checkout;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Tokens;
using Xunit.Abstractions;
using Environment = System.Environment;

namespace Seventy7Diamonds.Paymets.Application.Tests;

public class UnitTest1
{
    
    private readonly string _clientID = "ack_usg74gyctmau3lzxmpm4lvuhju";
    private readonly string _publicKey = "pk_sbox_g3iid7ew7clcwgyjn63gxhlc4mj";
    private readonly string _secretKey = "sk_sbox_vbgt3aucy7xnj7kftnrhxjmhpm2";
    private readonly string _authURI = "https://access.sandbox.checkout.com/connect/token";
    
    [Fact]
    public async Task Test1()
    {
        /*
        ICheckoutApi api = CheckoutSdk.Builder().OAuth()
            .ClientCredentials(_clientID, _clientSecret)
            .AuthorizationUri(new Uri(_authURI))
            .Scopes(OAuthScope.Files, OAuthScope.Flow, OAuthScope.PaymentContext)
            .Environment(Checkout.Environment.Sandbox)
            .Build();
            */
        
        ICheckoutApi api = CheckoutSdk.Builder().StaticKeys()
            .PublicKey(_publicKey)
            .SecretKey(_secretKey)
            .Environment(Checkout.Environment.Sandbox)
            .Build();
        

        try
        {
            //var r = await api.TokensClient().Request(cardTokenRequest, CancellationToken.None);
            var response = await api.PaymentsClient().RequestPayment(new PaymentRequest()
            {
                Amount = 1024,
                Currency = Currency.EUR,
                PaymentType = PaymentType.Regular,
                Description = "Test Payment via sdk",
                Reference = "AAAAAAAAAAAA",
            });
            
            Assert.NotNull(response);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }


    }
}