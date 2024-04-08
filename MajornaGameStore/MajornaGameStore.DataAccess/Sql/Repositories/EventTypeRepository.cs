using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class EventTypeRepository(MajornaDbContext context) : RepositoryBase<EventType, int>(context)
{
    public override Task UpdateAsync(EventType entity)
    {
        throw new NotImplementedException();
    }
}