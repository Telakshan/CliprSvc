using Clipr.Domain.Entities;
using Clipr.Infrastructure.Contracts.Infrastructure;
using Clipr.Infrastructure.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clipr.Application.Features.Commands.UploadVideo;

public class UploadVideoHandler: IRequestHandler<UploadVideoCommand, Unit>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IVideoUploadService _videoUploadService;
    private readonly ILogger<UploadVideoHandler> _logger;

    //Delete
    string _storagePath = string.Empty;
    string appDirectory = string.Empty;

    public UploadVideoHandler( , IVideoRepository videoRepository, ILogger<UploadVideoHandler> logger, IVideoUploadService videoUploadService)
    {
        _videoRepository = videoRepository;
        _videoUploadService = videoUploadService;   
        _logger = logger;

        appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        _storagePath = Path.Combine(appDirectory, "Storage");

    }

    public async Task<Unit> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
    {
        var videoPath = Path.Combine(_storagePath, request.VideoName);

        if (!Directory.Exists(Path.GetDirectoryName(videoPath)))
            Directory.CreateDirectory(Path.GetDirectoryName(videoPath)!);

        using (var stream = new FileStream(videoPath, FileMode.Create))
        {
            await request.VideoStream.CopyToAsync(stream);
        }

        return Unit.Value;
    }
}
