using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Services;

public class EventTypeService(IEventTypeRepository repository) : ServiceBase<EventType, int>(repository)
{
    
}