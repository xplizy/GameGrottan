using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class EventDetailViewModel(IClientEventsService detailService) : ViewModelBase<EventDto, int>(detailService)
{
    private readonly IClientEventsService _eventDetailService = detailService;

    public EventDto SelectedEvent { get; set; }

    public async Task OnInite(int id)
    {
        SelectedEvent = await _eventDetailService.GetByIdAsync(id);
    }
}