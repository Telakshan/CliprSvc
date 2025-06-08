using Clipr.Infrastructure.AwsClients; // For AmazonS3StorageClient and S3ConfigOptions
using Clipr.Infrastructure.Contracts.Infrastructure; // For IVideoUploadService
using Clipr.Infrastructure.Upload;         // For VideoUploadService
using Clipr.Infrastructure.Mail;
using Clipr.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;  // For IConfiguration
using Microsoft.Extensions.DependencyInjection; // For IServiceCollection
using System; // For Console.WriteLine

namespace Clipr.Infrastructure.Registration;

public static class AddInfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Preserve existing DbContext registration
        services.AddDbContext<CliprDbContext>(options =>
            options.UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("CliprConnectionString")!)
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }));

        // Configure S3 Options
        services.Configure<S3ConfigOptions>(configuration.GetSection(S3ConfigOptions.S3Config));

        // Register S3 Client
        // AmazonS3Client is thread-safe, so AmazonS3StorageClient can be a singleton.
        services.AddSingleton<AmazonS3StorageClient>();

        // Register Video Upload Service
        services.AddScoped<IVideoUploadService, VideoUploadService>();

        // Preserve any existing service registrations, for example:
        // services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        // services.AddScoped<IVideoRepository, VideoRepository>();
        // services.Configure<EmailSetting>(c => configuration.GetSection("EmailSettings"));
        // services.AddTransient<IEmailService, EmailService>();

        return services;
    }  
}
