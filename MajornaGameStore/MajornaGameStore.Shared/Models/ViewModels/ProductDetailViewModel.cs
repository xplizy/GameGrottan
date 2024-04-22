using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class ProductDetailViewModel(IClientProductService service) : ViewModelBase<ProductDto, int>(service)
{
    private readonly IClientProductService _productDetailService = service;
    public Product SelectedProduct { get; set; }

    public ProductDto SelectedProductDto { get; set; }
    public async Task OnInite(int id)
    {
        SelectedProduct = await _productDetailService.GetFullInfoByIdAsync(id);
        SelectedProductDto = await _productDetailService.GetByIdAsync(id);
    }
}