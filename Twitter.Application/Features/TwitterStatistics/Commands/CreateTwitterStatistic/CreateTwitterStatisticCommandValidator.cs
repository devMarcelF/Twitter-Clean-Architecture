using FluentValidation;
using Twitter.Application.Contracts.Persistence;
using Twitter.Domain.Entities;

namespace Twitter.Application.Features.TwitterStatistics.Commands.CreateTwitterStatistic
{
    public class CreateTwitterStatisticCommandValidator : AbstractValidator<CreateTwitterStatisticCommand>
    {
        private readonly ITwitterStatisticRepository _twitterStatisticRepository;

        public CreateTwitterStatisticCommandValidator()
        {

            RuleFor(p => p.NumberOfTweets)
                .NotEmpty().NotNull().WithMessage("{PropertyNumberOfTweets} is required.")
                .GreaterThan(0).WithMessage("{PropertyNumberOfTweets} is required.");

            RuleFor(p => p.Hashtag)
                .NotEmpty().NotNull().WithMessage("{PropertyHashtag} is required.")
                .MaximumLength(200).WithMessage("{PropertyHashtag} must not exceed 200 characters.");

            //RuleFor(p => p.Date)
            //    .NotEmpty().NotNull().WithMessage("{PropertyDate} is required.");
        }
    }
}
