using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


public static class DI
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddLogging();

        builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));
        builder.Services.AddOptions<MongoDbConfig>().Bind(builder.Configuration.GetSection(nameof(MongoDbConfig)));

        builder.Services.AddScoped<IMongoDbConnector, MongoDbConnector>();








        return builder;
    }







}
