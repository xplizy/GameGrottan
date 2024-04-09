using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ServiceBase<TMainType, TId>(IService<TMainType, TId> mainRepository) : IService<TMainType, TId> where TMainType : class
{
    protected readonly IService<TMainType, TId> MainRepository = mainRepository;
    public async Task<ICollection<TMainType>> GetAllAsync()
    {
        return await MainRepository.GetAllAsync();
    }

    public async Task<TMainType?> GetByIdAsync(TId id)
    {
        var entity = await MainRepository.GetByIdAsync(id);

        if (entity is null)
        {
            return null;
        }

        return entity;
    }

    public async Task<TMainType> AddAsync(TMainType entity)
    {
        var entityReturnedWithId = await MainRepository.AddAsync(entity);

        return entityReturnedWithId;
    }

    public async Task UpdateAsync(TMainType entity)
    {
        await MainRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(TId id)
    {
        await MainRepository.DeleteAsync(id);
    }
}