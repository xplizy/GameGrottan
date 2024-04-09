using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class EventTypeService(IEventTypeRepository repository) : ServiceBase<EventType, int>(repository)
{
    
}