
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

    public async Task AddToDB(EventDto eventDto)
    {
        var dbItems = await eventService.GetAllAsync();
        bool eventExists = dbItems.Any(e => e.Id == eventDto.Id);

        if (eventExists)
        {
            return;
        }
        var dbEvent = new EventDto
        {
            Name = eventDto.Name,
            Id = eventDto.Id,
            TypeId = eventDto.TypeId,
            Description = eventDto.Description,
            Price = eventDto.Price,
            SpotsLeft = eventDto.SpotsLeft,
            Start = eventDto.Start,
            End = eventDto.End
        };
        await eventService.AddAsync(dbEvent);

    }

    public async Task DeleteEventInDb(int id)
    {
        var dbItems = await eventService.GetAllAsync();
        bool eventExists = dbItems.Any(e => e.Id == id);

        if (eventExists)
        {
            await eventService.DeleteAsync(id);
            
        }
    }

    public async Task UpdateEventInDb(EventDto eventDto, int Id)
    {
        var dbItems = await eventService.GetAllAsync();
        bool eventExists = dbItems.Any(e => e.Id == Id);

        if (eventExists)
        {
            var dbEvent = new EventDto
            {
                Name = eventDto.Name,
                Id = eventDto.Id,
                TypeId = eventDto.TypeId,
                Description = eventDto.Description,
                Price = eventDto.Price,
                SpotsLeft = eventDto.SpotsLeft,
                Start = eventDto.Start,
                End = eventDto.End
            };
            await eventService.UpdateAsync(dbEvent);
        }
    }
   

}