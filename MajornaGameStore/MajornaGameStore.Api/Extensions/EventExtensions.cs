using MajornaGameStore.DataAccess.Entities;
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
        group.MapPost("/events", AddEvent);
        group.MapDelete("/{id}", DeleteEvent);
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

    public static async Task<IResult> UpdateEvent(EventService eventService, Event entity)
    {
        var events = await eventService.UpdateAsync(entity);

        if (events is false)
            return Results.NotFound();

        return Results.Ok(events);
    }

    public static async Task<IResult> AddEvent(EventService eventService, Event entity)
    {
        var events2 = await eventService.GetAllAsync();

        var events = eventService.AddAsync(entity);

        if (events2.Any(e => e.Id == events.Id))
        {
            return Results.BadRequest();
        }

        return Results.Ok(events);
    }

    public static async Task<IResult> DeleteEvent(EventService eventService, int id)
    {
        var events = eventService.DeleteAsync(id);

        if (events is null)
            return Results.NotFound();

        return Results.Ok();


    }
}