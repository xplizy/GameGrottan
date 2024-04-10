using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;
using MongoDB.Bson;

namespace MajornaGameStore.DataAccess.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    protected const string OrderCollection = "Orders";


    public Task<ICollection<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetByIdAsync(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public Task<Order> AddAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(ObjectId id)
    {
        throw new NotImplementedException();
    }
}