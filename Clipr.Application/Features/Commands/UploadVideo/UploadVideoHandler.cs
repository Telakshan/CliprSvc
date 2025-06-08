using Clipr.Infrastructure.Contracts.Infrastructure;
using Clipr.Infrastructure.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clipr.Application.Features.Commands.UploadVideo;

public class UploadVideoHandler: IRequestHandler<UploadVideoCommand, string>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IVideoUploadService _videoUploadService;
    private readonly ILogger<UploadVideoHandler> _logger;

    string _storagePath = string.Empty;
    string appDirectory = string.Empty;

    public UploadVideoHandler(IVideoRepository videoRepository, 
        IVideoUploadService videoUploadService, ILogger<UploadVideoHandler> logger)
    {
        _videoRepository = videoRepository;
        _videoUploadService = videoUploadService;   
        _logger = logger;

        appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        _storagePath = Path.Combine(appDirectory, "Storage");

    }

    public async Task<string> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
    {
        var videoPath = Path.Combine(_storagePath, request.VideoFile.FileName);

        if (!Directory.Exists(Path.GetDirectoryName(videoPath)))
            Directory.CreateDirectory(Path.GetDirectoryName(videoPath)!);

        using (var stream = new FileStream(videoPath, FileMode.Create))
        {
            var videoStream = request.VideoFile.OpenReadStream();
            await videoStream.CopyToAsync(stream, cancellationToken);
        }

        return videoPath;
    }
}
