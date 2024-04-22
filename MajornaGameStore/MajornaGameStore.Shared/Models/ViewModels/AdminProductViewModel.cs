using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class AdminProductViewModel(IClientProductService service) : ViewModelBase<ProductDto, int>(service)
{
    private readonly IClientProductService _productDetailService = service;

    public Product SelectedProduct { get; set; }

    //TODO: kolla om vi ska använda product eller productdto för den nedan
    public Product NewProduct { get; set; }

    public async Task SetSelectedProduct(int id)
    {
        SelectedProduct = await _productDetailService.GetFullInfoByIdAsync(id);


    }

}