using FluentValidation;

namespace UseCases;

public record QueryArticleDisplay(Guid ArticleId)
{
    public class Validator : AbstractValidator<QueryArticleDisplay>
    {
        public Validator()
        {
            RuleFor(x =>  x.ArticleId).NotNull();
        }
    }
}

