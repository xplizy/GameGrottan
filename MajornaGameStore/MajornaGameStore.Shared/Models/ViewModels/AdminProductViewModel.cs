using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class AdminProductViewModel(IClientProductService service) : ViewModelBase<ProductDto, int>(service)
{
    private readonly IClientProductService _productDetailService = service;


    //TODO: kolla om vi ska använda product eller productdto för den nedan
    public Product NewProduct { get; set; }

    public Product SelectedProduct { get; set; }

    #region EditProductProperties

    public string EditName { get; set; } = string.Empty;
    public double EditPrice { get; set; }
    public int EditProductTypeId { get; set; }
    public int EditDiscountId { get; set; } = 1;
    public string EditDescription { get; set; } = string.Empty;
    public string EditLanguages { get; set; } = string.Empty;
    public string EditImageLink { get; set; } = string.Empty;
    public string EditPcRequirements { get; set; } = string.Empty;
    public DateTime EditReleaseDate { get; set; } = new DateTime();
    public List<Developer> EditDevelopers { get; set; } = new();
    public List<Publisher> EditPublishers { get; set; } = new();
    public List<Screenshot> EditScreenshots { get; set; } = new();
    public List<Tag> EditTags { get; set; } = new();
    public int AgeRating { get; set; }

    #endregion


    public async Task SetSelectedProduct(int id)
    {
        SelectedProduct = await _productDetailService.GetFullInfoByIdAsync(id);
    }

    public async Task SaveUpdateChangesAsync()
    {

    }

}