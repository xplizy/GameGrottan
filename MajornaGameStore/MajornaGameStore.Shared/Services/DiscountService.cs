using MajornaGameStore.DataAccess.Entities;

using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class DiscountService(IDiscountRepository discountRepository) : ServiceBase<Discount, int>(discountRepository)
{
    
}