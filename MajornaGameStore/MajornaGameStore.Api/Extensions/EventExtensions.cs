using MajornaGameStore.DataAccess.Services;
using Microsoft.Identity.Client;

namespace MajornaGameStore.Api.Extensions;

public static class EventExtensions
{
    public static IEndpointRouteBuilder MapEventEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/events");


        group.MapGet("/", GetAllEventsAsync);
        group.MapGet("/{id}", GetEventsByIdAsync);
        group.MapPut("/{id}", UpdateEvent);
        return app;
    }

    public static async Task<IResult> GetAllEventsAsync(EventService eventService)
    {

        var events = await eventService.GetAllAsync();
        return Results.Ok(events);

    }

    public static async Task<IResult> GetEventsByIdAsync(EventService eventService, int id)
    {

        var events = await eventService.GetByIdAsync(id);

        if (events is null)
            return Results.NotFound();
        
        return Results.Ok(events);

    }

    public static async Task<IResult> UpdateEvent(EventService eventService, int id)
    {
        var events = await eventService.UpdateAsync();

        if (events is null)
            return Results.NotFound();

        return Results.Ok(events);
    }
}