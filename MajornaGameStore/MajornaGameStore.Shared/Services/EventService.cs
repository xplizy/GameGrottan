using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class EventService(IEventRepository eventRepository) : ServiceBase<Event, int>(eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

}