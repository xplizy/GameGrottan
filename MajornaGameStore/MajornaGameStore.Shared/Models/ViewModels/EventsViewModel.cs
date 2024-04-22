
using System.ComponentModel;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using Microsoft.AspNetCore.Components;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class EventsViewModel(IClientEventsService eventService, IClientCartService cartService) : ViewModelBase<EventDto, int>(eventService)
{
    private readonly IClientEventsService _eventService = eventService;
    private readonly IClientCartService _cartService = cartService;

    public async Task<int> TicketsCount(int eventId)
    {
        var cartItems = await cartService.GetAllAsync();
        int ticketsCount = 0;

        foreach (var item in cartItems)
        {
            if (item is CartTicketDto cartTicket && cartTicket.EventId == eventId)
            {
                ticketsCount += cartTicket.Quantity;
            }
        }
        return ticketsCount;
    }

    public async Task AddToCartAsync(EventDto eventDto, int quantity)
    {

        var cartItems = await cartService.GetAllAsync();
        foreach (var item in cartItems)
        {
            if (item is CartTicketDto)
            {
                CartTicketDto cartTicket = (CartTicketDto)item;

                if (cartTicket.EventId == eventDto.Id)
                {
                    item.Quantity += quantity;
                    return;
                }

            }
        }

        var cartItem = new CartTicketDto
        {
            Name = eventDto.Name,
            Price = eventDto.Price,
            EventId = eventDto.Id,
            Quantity = quantity
        };

        await cartService.AddAsync(cartItem);
    }

    
    
}