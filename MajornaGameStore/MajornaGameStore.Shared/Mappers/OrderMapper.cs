using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MongoDB.Bson;

namespace MajornaGameStore.Shared.Mappers;

public static class OrderMapper
{
    public static OrderDto MapToDtoAsync(this Order entity)
    {
        var productQuantityIds = new List<ObjectId>();
        foreach (var productQuantity in entity.ProductQuantities)
        {
            productQuantityIds.Add(productQuantity.Id);
        }
        var eventQuantityIds = new List<ObjectId>();
        foreach (var eventQuantity in entity.EventQuantities)
        {
            productQuantityIds.Add(eventQuantity.Id);
        }

        var dto = new OrderDto
        {
            Id = entity.Id.ToString(),
            UserId = entity.UserId,
            DateOfOrder = entity.DateOfOrder,
            ProductQuantityIds = productQuantityIds,
            EventQuantityIds = eventQuantityIds
        };
        return dto;
    }

    public static Order MapToEntityAsync(this OrderDto dto)
    {
        throw new NotImplementedException();
    }
}