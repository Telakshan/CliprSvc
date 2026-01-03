using Clipr.Infrastructure.AwsClients;
using Clipr.Infrastructure.AWSClients;
using Clipr.Infrastructure.Contracts.Infrastructure;
using Clipr.Infrastructure.Contracts.Persistence;
using Clipr.Infrastructure.Mail;
using Clipr.Infrastructure.Persistence;
using Clipr.Infrastructure.Repository;
using Clipr.Infrastructure.Upload;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clipr.Infrastructure;

public static class AddInfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CliprDbContext>(options =>
            options.UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("CliprConnectionString")!)
            .LogTo(Console.WriteLine, [DbLoggerCategory.Database.Command.Name]));

        /*        services
                    .AddOptions<S3Config>()
                    .BindConfiguration(nameof(S3Config))
                    .ValidateDataAnnotations()
                    .ValidateDataAnnotations()
                    .ValidateOnStart();*/

        services.Configure<S3Config>(c => configuration.GetSection(nameof(S3Config)));

        services.AddSingleton<AmazonS3StorageClient>();

        services.AddScoped<IVideoUploadService, VideoUploadService>();

        services.AddScoped(typeof(IAsyncRepository<,>), typeof(RepositoryBase<,>));
        services.AddScoped<IVideoRepository, VideoRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}