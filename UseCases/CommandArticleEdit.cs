using FluentValidation;

namespace UseCases;

public record CommandArticleEdit(Guid ArticleId, string Description, string Text)
{
    public class Validator : AbstractValidator<CommandArticleEdit>
    {
        public Validator()
        {
            RuleFor(x => x.ArticleId).NotNull();
            RuleFor(x =>  x.Description).NotNull().NotEmpty().MinimumLength(10).MaximumLength(100);
            RuleFor(x =>  x.Text).NotNull().NotEmpty().MinimumLength(100).MaximumLength(10000);

        }
    }
}

