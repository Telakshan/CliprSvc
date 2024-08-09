namespace Clipr.API.Registration;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder application)
    {
        return application.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
