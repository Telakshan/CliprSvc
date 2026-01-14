using Clipr.Modules.Upload.Application.Abstraction.Messaging;
using Clipr.Modules.Upload.Domain.Entities;

namespace Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;

public record UploadVideoCommand                          (
    string VideoName,
    VideoType VideoCategory,
    VideoStatus VideoStatus,
    byte[] VideoFile
    ) : ICommand<UploadVideoResponse>;
