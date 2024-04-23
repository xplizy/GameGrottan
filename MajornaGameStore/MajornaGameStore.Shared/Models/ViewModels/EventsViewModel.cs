
using System.ComponentModel;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class EventsViewModel(IClientEventsService eventService, IClientCartService cartService) : ViewModelBase<EventDto, int>(eventService)
{
    private readonly IClientEventsService _eventService = eventService;
    private readonly IClientCartService _cartService = cartService;


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
                    eventDto.SpotsLeft -= quantity;
                    if (eventDto.SpotsLeft is 0)
                    {
                        return;
                    }
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

    public async Task<int> SpotsLeftAsync(EventDto eventDto)
    {
        var cartItems = await cartService.GetAllAsync();
        var spotsLeft = eventDto.SpotsLeft;

        foreach (var item in cartItems)
        {
            if (item is CartTicketDto cartTicket && cartTicket.EventId == eventDto.Id)
            {
                spotsLeft -= cartTicket.Quantity;
            }
        }
        return spotsLeft;
    }

}