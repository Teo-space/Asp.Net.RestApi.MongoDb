using Domain;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
{
    builder.AddInfrastructure();
    builder.AddUseCases();



}

var app = builder.Build();
{
    //using var scope = app.Services.CreateScope();
    //var mongoDb = scope.ServiceProvider.GetRequiredService<IMongoDbConnector>();
    //var articles = mongoDb.GetCollection<Article>();

    //var article = new Article()
    //{
    //    ArticleId = Guid.Empty,
    //    Title = "Root",
    //    Description = "Description",
    //    Text = "Text",
    //    CreatedAt = DateTime.Now,
    //    UpdatedAt = DateTime.Now,
    //};

    //articles.InsertOne(article);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
