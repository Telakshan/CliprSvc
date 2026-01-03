using Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;
using Clipr.Modules.Upload.Domain.Abstractions;
using Clipr.Modules.Upload.Presentation.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Clipr.Modules.Upload.Presentation.Upload;

internal class CreateUpload
{
    public static void MapEnpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("upload", async (Request request, ISender sender) =>
        {

            Result<Guid> result = await sender.Send(new UploadVideoCommand());

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
            .WithTags(Tags.Upload);
    }

    internal sealed class Request
    {

    }
}
