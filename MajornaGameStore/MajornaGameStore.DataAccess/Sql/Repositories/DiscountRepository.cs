using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class DiscountRepository(MajornaDbContext context) : RepositoryBase<Event, int>(context)
{
    public override Task UpdateAsync(Event entity)
    {
        throw new NotImplementedException();
    }
}