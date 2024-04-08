using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;

namespace MajornaGameStore.DataAccess.Services;

public class EventService(EventRepository repository) : ServiceBase<Event, int>(repository)
{
    
}