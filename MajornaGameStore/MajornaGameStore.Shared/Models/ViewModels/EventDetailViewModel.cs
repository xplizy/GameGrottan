using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class EventDetailViewModel(IEventDetailService detailService) : ViewModelBase<EventDto, int>(detailService)
{
    private readonly IEventDetailService _eventDetailService = detailService;
}