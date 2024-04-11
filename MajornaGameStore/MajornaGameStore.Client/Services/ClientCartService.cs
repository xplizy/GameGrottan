using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientCartService : IClientCartService
{
    public List<ICartItem> Cart { get; set; } = new();
    public async Task<ICollection<ICartItem>> GetAllAsync()
    {
        return Cart.ToList();
    }

    public Task<ICartItem?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICartItem> AddAsync(ICartItem entity)
    {
        Cart.Add(entity);
        return entity;
    }

    public Task<bool> UpdateAsync(ICartItem entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var product = Cart.FirstOrDefault(o => o.Id == id);

        Cart.Remove(product);

        return true;
    }
}