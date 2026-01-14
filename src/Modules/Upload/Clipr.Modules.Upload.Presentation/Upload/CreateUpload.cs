using Clipr.Common.Domain.Abstractions;
using Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;
using Clipr.Modules.Upload.Domain.Entities;
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
                VideoType videoType = VideoType.Education;
                VideoStatus videoStatus = VideoStatus.Draft;
            
            Result<UploadVideoResponse> result = await sender.Send(new UploadVideoCommand(request.VideoName, videoType , videoStatus, request.VideoType));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
            .WithTags(Tags.Upload);
    }
}


internal sealed class Request
{
    public string VideoName { get; set; }   
    public string VideoCategory { get; set; }
    public string VideoStatus { get; set; }
    public byte[] VideFile { get; set; }
}
