using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class ProductDetailViewModel(IClientProductDetailService service) : ViewModelBase<ProductDto, int>(service)
{
    private readonly IClientProductDetailService _productDetailService = service;
    public ProductDto Product { get; private set; }

    public async Task LoadProductAsync(int productId)
    {
        
    }
}