using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class ProductViewModel(IClientProductService productService) : ViewModelBase<ProductDto, int>(productService)
{
    
}