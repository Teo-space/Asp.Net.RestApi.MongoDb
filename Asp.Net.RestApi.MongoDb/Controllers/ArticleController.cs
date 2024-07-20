namespace Asp.Net.RestApi.MongoDb.Controllers;

using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using UseCases;


[ApiController]
[Route("[controller]")]
public class ArticleController(ILogger<ArticleController> logger, IMongoDbConnector mongoDbConnector) : ControllerBase
{
    [HttpGet]//f462f47a-796e-4468-9669-2c866eb3a5db
    public Article GetArticle([FromQuery] QueryArticleDisplay request)
    {
        logger.LogInformation($"{this.HttpContext.Request.Method} {this.HttpContext.Request.Path}");

        return mongoDbConnector.GetCollection<Article>()
        .Find(x => x.ArticleId == request.ArticleId).FirstOrDefault();
    }

    [HttpPost]
    public Article CreateArticle([FromForm] CommandArticleCreate request)
    {
        logger.LogInformation($"{this.HttpContext.Request.Method} {this.HttpContext.Request.Path}");

        var article = Article.Create(request.Title, request.Description, request.Text);

        mongoDbConnector.GetCollection<Article>().InsertOne(article);

        return article;
    }

    [HttpPut]
    public Article EditArticle([FromForm] CommandArticleEdit request) 
    {
        logger.LogInformation($"{this.HttpContext.Request.Method} {this.HttpContext.Request.Path}");

        var article = mongoDbConnector.GetCollection<Article>()
        .Find(x => x.ArticleId == request.ArticleId).FirstOrDefault();

        if(article == null)
        {
            return default(Article);
        }
        article.Edit(request.Description, request.Text);

        var update = Builders<Article>.Update
            .Set(x => x.Description, article.Description)
            .Set(x => x.Text, article.Text)
            .Set(x => x.UpdatedAt, article.UpdatedAt)
            ;
        mongoDbConnector.GetCollection<Article>().UpdateOne(x => x.ArticleId == request.ArticleId, update);

        return article;
    }

    [HttpDelete]
    public Article DeleteArticle([FromForm] CommandArticleDelete request)
    {
        logger.LogInformation($"{this.HttpContext.Request.Method} {this.HttpContext.Request.Path}");

        return mongoDbConnector.GetCollection<Article>().FindOneAndDelete(x => x.ArticleId == request.ArticleId);
    }

}