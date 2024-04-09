using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Interfaces;

public interface ITagRepository : IService<Tag, int>
{
    Task<Tag?> GetByNameAsync(string name);
}