using Microsoft.AspNetCore.Http;

namespace Clipr.Modules.Upload.Infrastructure.Contracts.Infrastructure;

public interface IVideoUploadService
{
    Task<string> UploadVideoAsync(IFormFile videoFile);
}
