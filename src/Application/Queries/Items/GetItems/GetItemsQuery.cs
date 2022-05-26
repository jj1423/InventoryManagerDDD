using Application.DTOs.Items;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Items
{
    public class GetItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
    }
}
