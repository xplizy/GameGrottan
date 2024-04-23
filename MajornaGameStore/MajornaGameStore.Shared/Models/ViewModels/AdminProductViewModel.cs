using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class AdminProductViewModel(IClientProductService service, 
    IClientTypeService typeService, 
    IClientDiscountService discountService) : ViewModelBase<ProductDto, int>(service)
{
    private readonly IClientProductService _productDetailService = service;
    private readonly IClientTypeService _typeService = typeService;
    private readonly IClientDiscountService _discountService = discountService;


    //TODO: kolla om vi ska använda product eller productdto för den nedan
    public Product NewProduct { get; set; }

    public ProductModel SelectedProduct { get; set; }

    public List<ProductType> ProductTypes { get; set; }


    public async Task SetSelectedProduct(int id)
    {
        var selectedProd = await _productDetailService.GetFullInfoByIdAsync(id);

        //TODO: implementera null checkar för dessa två nedan
        var productType = await typeService.GetByIdAsync(selectedProd.ProductTypeId);
        var discount = await discountService.GetByIdAsync(selectedProd.DiscountId);

        SelectedProduct = new ProductModel()
        {
            Name = selectedProd.Name,
            Price = selectedProd.Price,
            ProductType = productType,
            Discount = discount,
            Description = selectedProd.Description,
            Languages = selectedProd.Languages,
            ImageLink = selectedProd.ImageLink,
            PcRequirements = selectedProd.PcRequirements,
            ReleaseDate = selectedProd.ReleaseDate,
            Developers = selectedProd.Developers,
            Publishers = selectedProd.Publishers,
            Screenshots = selectedProd.Screenshots,
            Tags = selectedProd.Tags,
            Reviews = selectedProd.Reviews,
            AgeRating = selectedProd.AgeRating
        };


    }

    public override async Task OnInit()
    {
        await base.OnInit();
        await 
    }

    public async Task SaveUpdateChangesAsync()
    {

    }

}