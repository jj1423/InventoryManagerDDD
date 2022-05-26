using MediatR;

namespace Application.Commands.Items
{
    /// <summary>
    /// Remove item command marked as a request that returns nothings
    /// </summary>
    public class RemoveItemCommand : IRequest
    {
        public string Name { get; init; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        public RemoveItemCommand(string name)
        {
            Name = name;
        }
    }
}
