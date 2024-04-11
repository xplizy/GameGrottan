using MajornaGameStore.Shared.CreatePayments;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MajornaGameStore.Shared.Models.ViewModels;

public class CartViewModel(IClientCartService cartService, IPaymentHttpClient paymentHttpClient) : ViewModelBase<ICartItem, string>(cartService)
{
    private readonly IClientCartService _cartService = cartService;
    private readonly IPaymentHttpClient _paymentHttpClient = paymentHttpClient;

    public async Task RemoveFromCart(string id)
    {
        await _cartService.DeleteAsync(id);

        var itemFromCart = Models.Find(i => i.Id == id);
        Models.Remove(itemFromCart!);

    }

    public async Task<string> GoToPayment()
    {
        var paymentRequest = new CreatePaymentRequest();
        paymentRequest.Products = new List<CartProductDto>
        {
            new CartProductDto
            {
                Name = "Joe game",
                Price = 99.9,
                Quantity = 2
            },
            new CartProductDto
            {
                Name = "Vivvy Game",
                Price = 100,
                Quantity = 3
            }
        };
        paymentRequest.CancelRedirectUrl = "http://www.google.se";
        paymentRequest.SuccessRedirectUrl = "http://www.bing.com";
        var checkoutUrl = await _paymentHttpClient.CreatePayment(paymentRequest);

        return checkoutUrl;
    }
}