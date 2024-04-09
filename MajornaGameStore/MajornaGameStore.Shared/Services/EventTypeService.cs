using MajornaGameStore.DataAccess.Entities;


namespace MajornaGameStore.DataAccess.Services;

public class EventTypeService(EventTypeRepository repository) : ServiceBase<EventType, int>(repository)
{
    
}