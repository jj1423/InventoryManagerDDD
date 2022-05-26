using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly()); // Registers all public non-abstract type that inherit from MeditR interfaces in this assembly (IRequestHandler, etc)
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Registers all public non-abstract type that inherit from AbstractValidator in this assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Registers all types decorated with IMapperFor from this assembly
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); // Registers the validation behavior

            return services;
        }
    }
}
