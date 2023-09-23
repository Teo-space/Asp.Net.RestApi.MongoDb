using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure;

internal class MongoDbConnector : IMongoDbConnector
{
    private readonly ILogger<MongoDbConnector> logger;
    private readonly MongoClient MongoClient;
    private readonly IMongoDatabase mongoDatabase;

    public MongoDbConnector(ILogger<MongoDbConnector> logger, IOptions<MongoDbConfig> options)
    {
        this.logger = logger;
        this.logger.LogInformation($"Connecting {options.Value.ConnectionString}, {options.Value.DatabaseName}");

        MongoClient = new MongoClient(options.Value.ConnectionString);
        mongoDatabase = MongoClient.GetDatabase(options.Value.DatabaseName);
    }


    public IMongoDatabase GetMongoDatabase() => mongoDatabase;

    public IMongoCollection<TDocument> GetCollection<TDocument>(string name) => mongoDatabase.GetCollection<TDocument>(name);
    public IMongoCollection<TDocument> GetCollection<TDocument>() => mongoDatabase.GetCollection<TDocument>(typeof(TDocument).Name);


}
