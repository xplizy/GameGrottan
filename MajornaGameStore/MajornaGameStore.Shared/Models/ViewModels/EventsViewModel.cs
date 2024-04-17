using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class EventsViewModel : ViewModelBase<EventDto, int>
{
    private readonly IClientEventsService _eventsService;
    public EventsViewModel(IClientEventsService eventsService) : base(eventsService)
    {
        _eventsService = eventsService;
    }


}