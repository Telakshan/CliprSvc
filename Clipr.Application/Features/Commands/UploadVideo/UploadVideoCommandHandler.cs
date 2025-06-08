using Clipr.Infrastructure.Contracts.Infrastructure;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clipr.Application.Features.Commands.UploadVideo
{
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
                throw new ArgumentException("Video file is required and cannot be empty.");
            }

            var videoUrl = await _videoUploadService.UploadVideoAsync(request.VideoFile);
            return videoUrl;
        }
    }
}
