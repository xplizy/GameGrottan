using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ServiceBase<TMainType, TId>(IService<TMainType, TId> mainRepository) : IService<TMainType, TId>
{
    protected readonly IService<TMainType, TId> MainRepository = mainRepository;
    public async Task<ICollection<TMainType>> GetAllAsync()
    {
        return await MainRepository.GetAllAsync();
    }

    public Task<TMainType?> GetByIdAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TMainType> AddAsync(TMainType entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TMainType entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }
}