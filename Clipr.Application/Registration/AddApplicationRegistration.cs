using Clipr.Application.Behaviors;
using Clipr.Application.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clipr.Application.Registration;

public static class AddApplicationRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Add services
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

        // Register AutoMapper using the extension method
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MappingProfile>(); 
        }, Assembly.GetExecutingAssembly());

        return services;
    }
}
