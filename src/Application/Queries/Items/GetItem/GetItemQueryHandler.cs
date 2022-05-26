using Application.DTOs.Items;
using AutoMapper;
using Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Items
{
    /// <summary>
    /// Get item query handler
    /// </summary>
    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="uow">Unit of work abstraction to inject into de class</param>
        /// <param name="mapper">Mapper abstraction to inject into de class</param>
        public GetItemQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Handler which processes the query when a client app executes it
        /// </summary>
        /// <param name="request">Query request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task which result contains the item</returns>
        public async Task<ItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _uow.Items.GetAsync(request.Id);
            return _mapper.Map<ItemDto>(item);
        }
    }
}
