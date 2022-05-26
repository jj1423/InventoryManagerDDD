using FluentValidation;

namespace Application.Commands.Items
{
    /// <summary>
    /// Remove item command validator that checks if the command is valid 
    /// </summary>
    public class RemoveItemCommandValidator : AbstractValidator<RemoveItemCommand>
    {
        /// <summary>
        /// Constructor that implements the rules
        /// </summary>
        public RemoveItemCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty();
        }
    }
}
