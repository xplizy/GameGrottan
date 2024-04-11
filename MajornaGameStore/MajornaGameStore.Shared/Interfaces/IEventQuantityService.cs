using MajornaGameStore.DataAccess.Entities;
using MongoDB.Bson;

namespace MajornaGameStore.Shared.Interfaces;

public interface IEventQuantityService : IService<EventQuantity, ObjectId>
{

}