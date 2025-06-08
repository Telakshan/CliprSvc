using MediatR;
using Clipr.Infrastructure.Contracts.Infrastructure; // For IVideoUploadService
using System.Threading;
using System.Threading.Tasks;
using System; // For ArgumentNullException

namespace Clipr.Application.Features.Commands.UploadVideo;

public class UploadVideoCommandHandler : IRequestHandler<UploadVideoCommand, string>
{
    private readonly IVideoUploadService _videoUploadService;

    public UploadVideoCommandHandler(IVideoUploadService videoUploadService)
    {
        _videoUploadService = videoUploadService ?? throw new ArgumentNullException(nameof(videoUploadService));
    }

    public async Task<string> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
    {
        if (request.VideoFile == null || request.VideoFile.Length == 0)
        {
            // This basic validation could also be handled by a validation behavior in MediatR pipeline
            throw new ArgumentException("Video file cannot be null or empty.", nameof(request.VideoFile));
        }

        var videoUrl = await _videoUploadService.UploadVideoAsync(request.VideoFile);

        // In a more complete scenario, you might save metadata about the video here
        // using another service/repository, e.g.:
        // var videoEntity = new Video { Url = videoUrl, Title = request.VideoFile.FileName, UploadedAt = DateTime.UtcNow };
        // await _videoRepository.AddAsync(videoEntity);

        return videoUrl;
    }
}
