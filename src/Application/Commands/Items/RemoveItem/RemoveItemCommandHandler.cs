using Application.Common.Exceptions;
using Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Items
{
    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand>
    {
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="uow">Unit of work abstraction to inject into de class</param>
        public RemoveItemCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Handler which processes the command when a client app executes it
        /// </summary>
        /// <param name="request">Command request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task which result contains nothing</returns>
        public async Task<Unit> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _uow.Items.GetByNameAsync(request.Name);

            if (item == null)
                throw new NotFoundException($"Item with name {request.Name} not found");

            // Removes the item from the inventory executing all business logic involved
            item.RemoveItemFromInventory();

            // Removes the item from the database
            _uow.Items.Delete(item);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
