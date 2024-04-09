using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ProductTypeService(ITypeRepository typeRepository) : ServiceBase<ProductType, int>(typeRepository)
{
    
}