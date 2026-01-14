using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;

public interface IUploadVideoCommandHandler
{
    Task<Result<UploadVideoResponse>> Handle(UploadVideoCommand request, CancellationToken cancellationToken);
}
