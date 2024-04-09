using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Interfaces;

public interface IProductRepository : IService<Product, int>
{
    Task<ICollection<Product>> GetByTagIdAsync(int tagId);
}