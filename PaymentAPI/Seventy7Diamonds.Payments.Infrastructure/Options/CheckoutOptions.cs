namespace Seventy7Diamonds.Payment.Infrastructure.Options;

public sealed class CheckoutOptions
{
    public CheckoutOptions(){}
    
    public string SecretKey { get; set; }
    public string PublicKey { get; set; }
    public Checkout.Environment Environment { get; set; }
    
    public string ProcessingChannelId { get; set; }
}