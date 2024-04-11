using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MajornaGameStore.Shared.Models.ViewModels;

public class CartViewModel(IClientCartService cartService, PaymentHttpClient paymentHttpClient) : ViewModelBase<ICartItem, string>(cartService)
{
    private readonly IClientCartService _cartService = cartService;
    public async Task RemoveFromCart(string id)
    {
        await _cartService.DeleteAsync(id);

        var itemFromCart = Models.Find(i => i.Id == id);
        Models.Remove(itemFromCart!);

    }

    public async Task GoToPayment()
    {

    }
}