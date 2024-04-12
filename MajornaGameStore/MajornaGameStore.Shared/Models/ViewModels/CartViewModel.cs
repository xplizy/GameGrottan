using MajornaGameStore.Shared.CreatePayments;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MajornaGameStore.Shared.Models.ViewModels;

public class CartViewModel(IClientCartService cartService, IPaymentHttpClient paymentHttpClient) : ViewModelBase<CartItemDto, string>(cartService)
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
        paymentRequest.Products = Models;
        paymentRequest.CancelRedirectUrl = "https://localhost:7207/fail";
        paymentRequest.SuccessRedirectUrl = "https://localhost:7207/checkout";
        var checkoutUrl = await _paymentHttpClient.CreatePayment(paymentRequest);

        Models.Clear();
        return checkoutUrl;
    }
}