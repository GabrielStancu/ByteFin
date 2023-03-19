using DataCollectionService.Data.Entities;
using DataCollectionService.Data.Settings;
using MongoDB.Driver;

namespace DataCollectionService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
{
    private readonly IMongoCollection<T> _collection;

    public GenericRepository(IDatabaseSettings<T> databaseSettings)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _collection = database.GetCollection<T>(databaseSettings.CollectionName);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(e => e.Id == id);
    }

    public async Task<T?> GetAsync(string id)
    {
        var entity = await _collection.FindAsync(e => e.Id == id);
        return await entity.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T?>?> GetAllAsync()
    {
        var entities = await _collection.FindAsync(FilterDefinition<T>.Empty);
        return await entities.ToListAsync();
    }

    public async Task SaveAsync(T entity)
    {
        var dbEntity = await GetAsync(entity.Id);

        if (dbEntity is null)
        {
            await _collection.InsertOneAsync(entity);
        }
        else
        {
            await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }
    }

    public async Task SoftDeleteAsync(string id)
    {
        var entity = await GetAsync(id);

        if (entity is null)
            return;

        entity.Deleted = true;
        await _collection.ReplaceOneAsync(e => e.Id == id, entity);
    }

    public async Task<T?> GetLastOccurrenceAsync()
    {
        var entities = await _collection.Aggregate()
            .Group(e => e.Id,
                   g => new {
                        Id = g.Key,
                        LatestTimestamp = g.Max(d => d.TimestampUtc)
                   })
            .ToListAsync();
        var lastEntity = entities.FirstOrDefault();

        if (lastEntity is null)
            return null;

        return await GetAsync(lastEntity.Id);
    }
}
