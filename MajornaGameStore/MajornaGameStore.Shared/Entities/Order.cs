using MongoDB.Bson;

namespace MajornaGameStore.DataAccess.Entities;

public class Order : EntityBase<ObjectId>
{

    public string UserId { get; set; }

    public ICollection<ProductQuantity> ProductQuantityIds { get; set; }

    public DateTime DateOfOrder { get; set; }
}