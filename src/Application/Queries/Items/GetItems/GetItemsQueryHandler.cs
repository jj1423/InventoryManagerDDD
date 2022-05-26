using Application.DTOs.Items;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Items
{
    /// <summary>
    /// Get items query
    /// </summary>
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="uow">Unit of work abstraction to inject into de class</param>
        /// <param name="mapper">Mapper abstraction to inject into de class</param>
        public GetItemsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Handler which processes the query when a client app executes it
        /// </summary>
        /// <param name="request">Query request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task which result contains the the collection of items</returns>
        public async Task<IEnumerable<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _uow.Items.GetAllAsync();
            return items.AsQueryable().ProjectTo<ItemDto>(_mapper.ConfigurationProvider);
        }
    }
}
