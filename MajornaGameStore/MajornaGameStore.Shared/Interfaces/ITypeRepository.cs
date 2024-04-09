using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Interfaces;

public interface ITypeRepository : IService<ProductType, int>
{
    Task<ProductType?> GetByNameAsync(string name);
}