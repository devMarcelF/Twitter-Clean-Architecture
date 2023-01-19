using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Features.TwitterStatistics.Commands.UpdateTwitterStatistic
{
    public class UpdateTwitterStatisticCommandValidator : AbstractValidator<UpdateTwitterStatisticCommand>
    {
        public UpdateTwitterStatisticCommandValidator()
        {
            RuleFor(p => p.Hashtag)
                .NotEmpty().WithMessage("{PropertyHashtag} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.NumberOfTweets)
                .NotEmpty().WithMessage("{PropertyNumberOfTweets} is required.")
                .GreaterThan(0);
        }
    }
}
