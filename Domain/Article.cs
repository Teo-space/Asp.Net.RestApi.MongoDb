namespace Domain;
using MongoDB.Bson.Serialization.Attributes;



public class Article
{
    [BsonId]
    public Guid ArticleId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public string Text { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


    public static Article Create(string Title, string Description, string Text)
    {
        var article = new Article
        {
            ArticleId = Guid.NewGuid(),
            Title = Title,
            Description = Description,
            Text = Text,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        return article;
    }

    public Article Edit(string Description, string Text)
    {
        this.Description = Description;
        this.Text = Text;
        this.UpdatedAt = DateTime.Now;
        return this;
    }










}