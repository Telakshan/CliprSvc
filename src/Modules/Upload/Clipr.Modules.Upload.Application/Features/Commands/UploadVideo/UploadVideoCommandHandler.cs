using Clipr.Common.Domain.Abstractions;
using Clipr.Modules.Upload.Application.Abstraction.Messaging;
using Clipr.Modules.Upload.Domain.Entities;
using Clipr.Modules.Upload.Domain.Upload;

namespace Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;

public class UploadVideoCommandHandler(IVideoUploadService videoUploadService, IVideoRepository videoRepository) : ICommandHandler<UploadVideoCommand, UploadVideoResponse>
{
    public async Task<Result<UploadVideoResponse>> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
    {
        string videoUrl = await videoUploadService.UploadVideoAsync(request.VideoFile);

        Video video = await videoRepository.AddAsync(new Video
        {
            UserId = Guid.NewGuid(),
            VideoName = request.VideoName,
            VideoCategory = request.VideoCategory,
            Status = request.VideoStatus,
            VideoUrl = new Uri(videoUrl)
        });


        if (string.IsNullOrEmpty(videoUrl))
        {
            return Result.Failure<UploadVideoResponse>(UploadErrors.UploadFailed);
        }

        return Result.Success(new UploadVideoResponse(video.Id, video.VideoUrl!));
    }
}
