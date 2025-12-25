using Clipr.Modules.Upload.Application.Abstraction.Messaging;
using Clipr.Modules.Upload.Domain.Abstractions;
using Clipr.Modules.Upload.Domain.Entities;
using Clipr.Modules.Upload.Domain.Upload;
using Clipr.Modules.Upload.Infrastructure.Contracts.Infrastructure;
using Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;

namespace Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;

public class UploadVideoCommandHandler(IVideoUploadService videoUploadService, IVideoRepository videoRepository) : ICommandHandler<UploadVideoCommand, UploadVideoResponse>
{
    public async Task<Result<UploadVideoResponse>> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
    {
        if (request.VideoFile == null || request.VideoFile.Length == 0)
        {
            throw new ArgumentException("Video file is required and cannot be empty.");
        }

        string videoUrl = await videoUploadService.UploadVideoAsync(request.VideoFile).ConfigureAwait(false);

        Video video = await videoRepository.AddAsync(new Video
        {
            UserId = Guid.NewGuid(),
            VideoName = request.VideoFile.FileName,
            VideoCategory = request.VideoCategory,
            Status = request.VideoStatus,
            VideoUrl = new Uri(videoUrl)
        });


        if (string.IsNullOrEmpty(videoUrl))
        {
            return Result.Failure<UploadVideoResponse>(UploadErrors.UploadFailed);
        }

        return Result.Success<UploadVideoResponse>(new UploadVideoResponse(video.Id, video.VideoUrl!));
    }
}
