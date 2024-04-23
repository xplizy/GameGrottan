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


    public List<ProductType> ProductTypes { get; set; } = new();
    public int SelectedProductTypeUpdateId { get; set; } = 0;


    public async Task SetSelectedProduct(int id)
    {
        var selectedProd = await _productDetailService.GetFullInfoByIdAsync(id);

        //TODO: implementera null checkar för dessa två nedan
        var productType = await typeService.GetByIdAsync(selectedProd.ProductTypeId);
        var discount = await discountService.GetByIdAsync(selectedProd.DiscountId);

        SelectedProduct = new ProductModel()
        {
            Id = selectedProd.Id,
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
        var types = await _typeService.GetAllAsync();
        ProductTypes.AddRange(types);
    }

    public async Task RemoveDeveloperAsync(Developer dev)
    {
        SelectedProduct.Developers.Remove(dev);
    }

    public async Task UpdateProductTypeAsync()
    {
        if (SelectedProductTypeUpdateId == 0)
            return;
        var type = ProductTypes.Find(t => t.Id == SelectedProductTypeUpdateId);
        SelectedProduct.ProductType = type;
        await SaveUpdateChangesAsync();
        SelectedProductTypeUpdateId = 0;
    }
    public async Task SaveUpdateChangesAsync()
    {

    }

}