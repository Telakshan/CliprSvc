using Clipr.Application.Behaviors;
using Clipr.Application.Registration;
using Clipr.Infrastructure;
using Clipr.Infrastructure.AWSClients;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddOptions<S3Config>()
    .BindConfiguration(nameof(S3Config))
    .ValidateDataAnnotations()
    .ValidateOnStart();

//Register services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
