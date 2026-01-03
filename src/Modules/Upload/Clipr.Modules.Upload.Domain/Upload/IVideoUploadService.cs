namespace Clipr.Modules.Upload.Domain.Upload;

public interface IVideoUploadService
{
    Task<string> UploadVideoAsync(byte[] videoFile);
}
