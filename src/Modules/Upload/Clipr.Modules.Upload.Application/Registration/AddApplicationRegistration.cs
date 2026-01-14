using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clipr.Modules.Upload.Application.Registration;

public static class AddApplicationRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Add services
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
