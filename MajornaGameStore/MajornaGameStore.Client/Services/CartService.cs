using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Client.Services;


public class CartService : ICartService
{
    
    public List<CartItemDto> CartItems { get; set; } = new();

    public async Task AddItemToCartAsync(CartItemDto cartItem)
    {
        CartItems.Add(cartItem);
    }
}