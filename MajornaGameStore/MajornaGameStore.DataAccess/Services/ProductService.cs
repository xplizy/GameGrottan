using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ProductService(IProductRepository repository, ITypeRepository typeRepository, ITagRepository tagRepository) : ServiceBase<Product, int>(repository)
{
    private readonly IProductRepository _productRepository = repository;
    private readonly ITypeRepository _typeRepository = typeRepository;
    private readonly ITagRepository _tagRepository = tagRepository;
    public async Task<ICollection<Product>> GetAllProductsByTypeAsync(int productTypeId)
    {
        var doesTypeExist = await _typeRepository.GetByIdAsync(productTypeId);

        if (doesTypeExist is null)
            return new List<Product>();

        var products = await MainRepository.GetAllAsync();
        var productsByType =  products
            .ToList()
            .Where(p => p.ProductTypeId == productTypeId)
            .ToList();

        return productsByType;
    }

    public async Task<ICollection<Product>> GetAllProductsByTag(int tagId)
    {
        var doesTagExist = await _tagRepository.GetByIdAsync(tagId);

        if(doesTagExist is null)
            return new List<Product>();

        var products = await _productRepository.GetByTagIdAsync(tagId);

        return products;
    }

    
}