using Checkout;

namespace Seventy7Diamonds.Payments.Application.Tests;

/// <summary>
/// A fixture to be used on Checkout Sandbox
/// </summary>
public class CheckoutApiSandboxFixture : IDisposable
{
    public const string PublicKey = "pk_sbox_szo5m4izt7xqr5g7uvc3j6wolit";
    public const string SecretKey = "sk_sbox_vzsdl6tauei3bdkxftatbunr5al";
    public const string ProcessingChannelId = "pc_d7u3ecyxckteldjo4a33dbqfby";
    
    public readonly ICheckoutApi CheckoutApi;

    public CheckoutApiSandboxFixture()
    {
        CheckoutApi = CheckoutSdk.Builder().StaticKeys()
            .PublicKey(PublicKey)
            .SecretKey(SecretKey)
            .Environment(Checkout.Environment.Sandbox)
            .Build();
    }

    public void Dispose()
    {
    }
}