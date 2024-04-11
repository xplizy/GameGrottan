using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class ProductViewModel(IClientProductService productService, IClientCartService cartService) : ViewModelBase<ProductDto, int>(productService)
{
    private readonly IClientCartService _cartService = cartService;

    public async Task AddToCartAsync(ProductDto product, int quantity)
    {
        var cartItems = await cartService.GetAllAsync();
        foreach (var item in cartItems)
        {
            if (item is CartProductDto)
            {
                (CartProductDto)item.
            }
        }

        var cartItem = new CartProductDto
        {
            Image = product.ImageLink,
            Name = product.Name,
            Price = product.Price,
            ProductId = product.Id,
            Quantity = 1
        };
    }
}