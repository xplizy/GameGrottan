using MajornaGameStore.Shared.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MajornaGameStore.DataAccess.Mongo;

public class MongoRepositoryBase<TEntity> 
{
    protected const string ConnectionsString = "mongdodb://localhost:27017";
    protected const string DataBaseName = "MajornaOrderDb";

    //These are here for reference only
    protected const string OrderCollection = "Orders";
    protected const string ProductQuantityCollection = "ProductQuantity";

    protected IMongoCollection<T> ConnectToMongo<T>(string collectionName)
    {
        var client = new MongoClient(ConnectionsString);
        var db = client.GetDatabase(DataBaseName);
        return db.GetCollection<T>(collectionName);
    }
   
    public async Task<ICollection<TEntity>> GetAllAsync(string collectionName)
    {
        var collection = ConnectToMongo<TEntity>(collectionName);

        var filter = Builders<TEntity>.Filter.Empty;

        var results = await collection.FindAsync(filter);

        return await results.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(ObjectId id, string collectionName)
    {
        var collection = ConnectToMongo<TEntity>(collectionName);

        var filter = Builders<TEntity>.Filter.Eq("Id", id);

        var entity = await collection.Find(filter).FirstOrDefaultAsync();

        return entity;
    }
    //TODO: doublecheck that this actually returns the entity with the newly generated ID
    public async Task<TEntity> AddAsync(TEntity entity, string collectionName)
    {
        var collection = ConnectToMongo<TEntity>(collectionName);

        await collection.InsertOneAsync(entity);

        return entity;
    }

    public async Task UpdateAsync(TEntity entity, ObjectId id, string collectionName)
    {
        var quizCollection = ConnectToMongo<TEntity>(collectionName);


        var filter = Builders<TEntity>.Filter.Eq("Id", id);
        var replaceOptions = new ReplaceOptions { IsUpsert = true };

        await quizCollection.ReplaceOneAsync(filter, entity, replaceOptions);
    }

    public async Task DeleteAsync(ObjectId id, string collectionName)
    {
        var quizCollection = ConnectToMongo<TEntity>(collectionName);

        var filter = Builders<TEntity>.Filter.Eq("Id", id);

        await quizCollection.DeleteOneAsync(filter);
    }
}