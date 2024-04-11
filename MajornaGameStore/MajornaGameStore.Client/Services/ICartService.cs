using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Client.Services;

public interface ICartService
{
    //event Action<CartItemDto> ItemAddedToCart;
    public List<CartItemDto> CartItems { get; set; }
    Task AddItemToCartAsync(CartItemDto cartItem);
}