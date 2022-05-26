using Domain.AggregatesModel.ItemAggregate;
using MediatR;
using System;

namespace Application.Commands.Items
{
    /// <summary>
    /// Create item command marked as a request that returns an int (the id of the created item)
    /// </summary>
    public class CreateItemCommand : IRequest<int>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public ItemType Type { get; init; }
        public DateTime ExpirationDate { get; init; }
        public float Weight { get; init; }
    }
}
