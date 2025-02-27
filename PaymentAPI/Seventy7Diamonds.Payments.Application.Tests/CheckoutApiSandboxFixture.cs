using Checkout;

namespace Seventy7Diamonds.Payments.Application.Tests;

/// <summary>
/// A fixture to be used on
/// </summary>
public class CheckoutApiSandboxFixture : IDisposable
{
    public const string ClientID = "ack_usg74gyctmau3lzxmpm4lvuhju";
    public const string PublicKey = "pk_sbox_g3iid7ew7clcwgyjn63gxhlc4mj";
    public const string SecretKey = "sk_sbox_vbgt3aucy7xnj7kftnrhxjmhpm2";
    public const string ProcessingChannelId = "pc_7b4tpe676mue3bao5nvj5ovzem";
    public const string AuthURI = "https://access.sandbox.checkout.com/connect/token";
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