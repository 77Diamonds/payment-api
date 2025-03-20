namespace Seventy7Diamonds.Payment.Infrastructure.Options;

public sealed class CheckoutOptions
{
    public const string SectionName = "Checkout";
    
    public CheckoutOptions(){}
    
    public required string SecretKey { get; set; }
    public required string PublicKey { get; set; }
    public required Checkout.Environment Environment { get; set; }
    public required string ProcessingChannelId { get; set; }
}