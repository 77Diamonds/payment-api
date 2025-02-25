using Checkout;

namespace Seventy7Diamonds.Payments.Application.Services;


/// <summary>
/// Indirection layer to access the "checkout.com" services
/// </summary>
public class CheckoutServices
{
    private readonly ICheckoutApi _checkoutApi;

    public CheckoutServices(ICheckoutApi checkoutApi)
    {
        _checkoutApi = checkoutApi;
    }
}