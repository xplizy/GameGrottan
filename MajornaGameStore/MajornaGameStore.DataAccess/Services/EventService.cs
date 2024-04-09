using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class EventService(IEventRepository eventRepository) : ServiceBase<Event, int>(eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

}