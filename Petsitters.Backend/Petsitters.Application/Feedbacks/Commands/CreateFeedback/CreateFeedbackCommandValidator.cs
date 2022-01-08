using System;
using FluentValidation;

namespace Petsitters.Application.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(createFeedbackCommand =>
                createFeedbackCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createFeedbackCommand =>
                createFeedbackCommand.Text).NotEmpty().MaximumLength(1000);
            RuleFor(createFeedbackCommand =>
                createFeedbackCommand.Mark).LessThan(10);
            RuleFor(createFeedbackCommand =>
                createFeedbackCommand.WorkerUserId).NotEqual(null);
            RuleFor(createFeedbackCommand =>
                createFeedbackCommand.OwnerUserId).NotEqual(null);
        }
    }
}
