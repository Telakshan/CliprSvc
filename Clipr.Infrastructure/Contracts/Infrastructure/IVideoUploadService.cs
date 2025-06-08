using Microsoft.AspNetCore.Http;

namespace Clipr.Infrastructure.Contracts.Infrastructure;

public interface IVideoUploadService
{
    Task<string> UploadVideoAsync(IFormFile videoFile);
}
