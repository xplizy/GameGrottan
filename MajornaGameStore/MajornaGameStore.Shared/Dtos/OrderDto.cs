using MajornaGameStore.DataAccess.Entities;
using MongoDB.Bson;

namespace MajornaGameStore.Shared.Dtos;

public class OrderDto
{
    public string Id { get; set; }
    public string UserId { get; set; } = "Anonymous";
    public ICollection<ObjectId> ProductQuantityIds { get; set; }
    public ICollection<ObjectId> EventQuantityIds { get; set; }

    public DateTime DateOfOrder { get; set; }
}