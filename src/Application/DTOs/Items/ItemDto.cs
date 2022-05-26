using Application.Common.Mapping;
using Domain.AggregatesModel.ItemAggregate;
using System;

namespace Application.DTOs.Items
{
    /// <summary>
    /// DTO that represent a Item domain entity to return to the client apps
    /// </summary>
    public class ItemDto : IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public float Weight { get; set; }

        // Mapping method can be override, for example:
        /*
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name + "-sufix"));
        }
        */
    }
}
