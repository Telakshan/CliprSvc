namespace Clipr.Infrastructure.Contracts.Infrastructure;

public interface IVideoUploadService
{
    public Task<string> UploadVideoAsync(string videoPath);
}
