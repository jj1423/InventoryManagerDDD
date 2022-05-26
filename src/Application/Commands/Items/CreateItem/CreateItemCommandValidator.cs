using FluentValidation;
using System;

namespace Application.Commands.Items
{
    /// <summary>
    /// Created item command validator that checks if the command is valid 
    /// </summary>
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        /// <summary>
        /// Constructor that implements the rules
        /// </summary>
        public CreateItemCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty().MaximumLength(100);
            RuleFor(cmd => cmd.Description).NotEmpty().MaximumLength(250);
            RuleFor(cmd => cmd.Type).NotEmpty().IsInEnum();
            RuleFor(cmd => cmd.ExpirationDate).Must(BeValidExpirationDate).WithMessage("Please specify a valid expiration date."); ;
            RuleFor(cmd => cmd.Weight).NotEmpty();
        }

        /// <summary>
        /// Checks if the expiration date is valid (not a past date)
        /// </summary>
        /// <param name="expirationDateTime">Expiration date time</param>
        /// <returns>True is valid</returns>
        private bool BeValidExpirationDate(DateTime expirationDateTime)
        {
            return expirationDateTime >= DateTime.UtcNow;
        }
    }
}
