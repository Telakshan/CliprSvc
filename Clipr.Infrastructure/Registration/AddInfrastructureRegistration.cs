using Clipr.Infrastructure.AwsClients;
using Clipr.Infrastructure.Contracts.Infrastructure;
using Clipr.Infrastructure.Upload;
using Clipr.Infrastructure.Mail;
using Clipr.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Clipr.Infrastructure;

public static class AddInfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CliprDbContext>(options =>
            options.UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("CliprConnectionString")!)
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }));

        services.Configure<S3ConfigOptions>(configuration.GetSection(S3ConfigOptions.S3Config));

        services.AddSingleton<AmazonS3StorageClient>();

        services.AddScoped<IVideoUploadService, VideoUploadService>();

        // services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        // services.AddScoped<IVideoRepository, VideoRepository>();
        // services.Configure<EmailSetting>(c => configuration.GetSection("EmailSettings"));
        // services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
