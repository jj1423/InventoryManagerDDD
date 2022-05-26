using FluentValidation;

namespace Application.Queries.Items
{
    /// <summary>
    /// Get item query validator that checks if the query is valid 
    /// </summary>
    public class GetItemQueryValidator : AbstractValidator<GetItemQuery>
    {
        /// <summary>
        /// Constructor that implements the rules
        /// </summary>
        public GetItemQueryValidator()
        {
            RuleFor(q => q.Id).NotEmpty().GreaterThan(0);
        }
    }
}
