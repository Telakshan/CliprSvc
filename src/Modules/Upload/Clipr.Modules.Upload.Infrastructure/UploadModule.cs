using Clipr.Modules.Upload.Infrastructure.Registration;
using Clipr.Modules.Upload.Presentation.Upload;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Clipr.Modules.Upload.Infrastructure;

public static class UploadModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        UploadEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddUploadModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);

        return services;
    }
}
