using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class EventRepository(MajornaDbContext context) : RepositoryBase<Event, int>(context)
{
    private readonly MajornaDbContext _context = context;
    public override async Task UpdateAsync(Event entity)
    {
        var eventFromDb = await _context.Events.FindAsync(entity.Id);

        if (eventFromDb is null)
            return;

        eventFromDb.Name = entity.Name;
        eventFromDb.Description = entity.Description;
        eventFromDb.Price = entity.Price;
        eventFromDb.EventTypeId = entity.EventTypeId;
        eventFromDb.EventStart = entity.EventStart;
        eventFromDb.EventEnd = entity.EventEnd;
        eventFromDb.Users = entity.Users;

        await _context.SaveChangesAsync();
    }
}