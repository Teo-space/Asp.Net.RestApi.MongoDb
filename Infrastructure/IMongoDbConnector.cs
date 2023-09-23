using MongoDB.Driver;

namespace Infrastructure;

public interface IMongoDbConnector
{
    public IMongoDatabase GetMongoDatabase();

    public IMongoCollection<TDocument> GetCollection<TDocument>(string name);
    public IMongoCollection<TDocument> GetCollection<TDocument>();
}



