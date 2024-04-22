using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class ProductDetailViewModel(IClientProductService service) : ViewModelBase<ProductDto, int>(service)
{
    private readonly IClientProductService _productDetailService = service;
    public ProductDto Product { get; private set; }

    public async Task LoadProductAsync(int productId)
    {
        
    }
}