using MongoDB.Driver;
using ShipService.Data;
using ShipService.Persistence.Settings;

namespace ShipService.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
{
    protected readonly IMongoCollection<T> Collection;

    public GenericRepository(IDatabaseSettings<T> databaseSettings)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        Collection = database.GetCollection<T>(databaseSettings.CollectionName);
    }

    public async Task DeleteAsync(string id)
    {
        await Collection.DeleteOneAsync(e => e.Id == id);
    }

    public async Task<T?> GetAsync(string id)
    {
        var entity = await Collection.FindAsync(e => e.Id == id);
        return await entity.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = await Collection.FindAsync(FilterDefinition<T>.Empty);
        return await entities.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllNotDeletedAsync()
    {
        var entities = await Collection.FindAsync(e => !e.Deleted);
        return await entities.ToListAsync();
    }

    public async Task SaveAsync(T entity)
    {
        if (entity.Id is null)
            return;

        var dbEntity = await GetAsync(entity.Id);

        if (dbEntity is null)
        {
            await Collection.InsertOneAsync(entity);
        }
        else
        {
            await Collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }
    }

    public async Task SoftDeleteAsync(string id)
    {
        var entity = await GetAsync(id);

        if (entity is null)
            return;

        entity.Deleted = true;
        await Collection.ReplaceOneAsync(e => e.Id == id, entity);
    }
}