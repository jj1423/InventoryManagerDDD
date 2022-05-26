using Application.DTOs.Items;
using MediatR;

namespace Application.Queries.Items
{
    /// <summary>
    /// Get item query
    /// </summary>
    public class GetItemQuery : IRequest<ItemDto>
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id"></param>
        public GetItemQuery(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }
}
