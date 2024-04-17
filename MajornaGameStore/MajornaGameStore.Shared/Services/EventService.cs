using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Logging;

namespace MajornaGameStore.DataAccess.Services;

public class EventService(IEventRepository eventRepository) : ServiceBase<Event, int>(eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<ICollection<Event>> GetAllAsync()
    {
        return await _eventRepository.GetAllAsync();
    }
    


}