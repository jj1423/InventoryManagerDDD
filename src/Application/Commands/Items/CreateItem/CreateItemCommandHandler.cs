using Domain.AggregatesModel.ItemAggregate;
using Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Items
{
    /// <summary>
    /// Create item command handler
    /// </summary>
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="uow">Unit of work abstraction to inject into de class</param>
        public CreateItemCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Handler which processes the command when a client app executes it
        /// </summary>
        /// <param name="request">Command request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task which result contains the id of the created item</returns>
        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            // Creates the new item (it must handle all the business logic like add the domain event for example)
            var item = new Item(request.Name, request.Description, request.Type, request.ExpirationDate, request.Weight);

            // Adds the element into database
            var id = await _uow.Items.AddAsync(item);
            await _uow.SaveChangesAsync();
            return id;
        }
    }
}
