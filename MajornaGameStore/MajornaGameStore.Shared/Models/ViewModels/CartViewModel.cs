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

    public async Task GoToPayment()
    {
        var paymentRequest = new CreatePaymentRequest();
        paymentRequest.Products = Models;
    }
}