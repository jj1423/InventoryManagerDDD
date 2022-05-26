using AutoMapper;

namespace Application.Common.Mapping
{
    /// <summary>
    /// Interface to mark a class to be mapped from another
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Creates a mapping configuration from the source entity type T to the destination type (the entity class which implements the interface)
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
