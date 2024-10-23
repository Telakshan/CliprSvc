using Clipr.Infrastructure.Mail;
using Clipr.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clipr.Infrastructure.Registration;

public static class AddInfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CliprDbContext>(options =>
            options.UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("CliprConnectionString")!)
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }));

        //services.AddOptions<EmailSettings>


        return services;
    }  
}
