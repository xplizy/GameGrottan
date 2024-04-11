using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Mongo;

public class ProductQuantityRepository : MongoRepositoryBase<ProductQuantity>, IProductQuantityRepository
{
    
}