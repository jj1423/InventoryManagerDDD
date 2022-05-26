using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Application.Common.Mapping
{
    /// <summary>
    /// Class to define a mapping profile for AutoMapper
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Configures the mapping for classes which implements the IMapFrom interface into the specified assembly
        /// </summary>
        /// <param name="assembly">Assembly in which to look for the types</param>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // Gets al types which implements the IMapFrom interface
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                // Checks if the type has got an own implementation of the Mapping method
                var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
