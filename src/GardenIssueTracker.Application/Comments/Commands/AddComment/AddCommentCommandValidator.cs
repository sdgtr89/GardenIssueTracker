using FluentValidation;
using GardenIssueTracker.Domain.Entities;

namespace GardenIssueTracker.Application.Comments.Commands.AddComment
{
    public class AddCommentCommandValidator : AbstractValidator<Comment>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(pv => pv.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} must be filled in.")
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(pv => pv.IsIssue)
                .NotEmpty()
                .WithMessage("Please indicate whether or not this Comment is describing an issue.");

            RuleFor(pv => pv.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} must be filled in.")
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
