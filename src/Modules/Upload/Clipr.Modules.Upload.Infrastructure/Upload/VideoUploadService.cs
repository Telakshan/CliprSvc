using Clipr.Modules.Upload.Infrastructure.AWSClients;
using Clipr.Modules.Upload.Infrastructure.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Clipr.Modules.Upload.Infrastructure.Upload;

public class VideoUploadService : IVideoUploadService
{
    private readonly AmazonS3StorageClient _s3Client;

    public VideoUploadService(AmazonS3StorageClient s3Client)
    {
        _s3Client = s3Client ?? throw new ArgumentNullException(nameof(s3Client));
    }

    public async Task<string> UploadVideoAsync(IFormFile videoFile)
    {
        if (videoFile == null || videoFile.Length == 0)
        {
            throw new ArgumentException("Video file cannot be null or empty.", nameof(videoFile));
        }

        string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(videoFile.FileName)}";

        //ACTUAL CODE

        using Stream stream = videoFile.OpenReadStream();

        string result = await _s3Client.UploadFileAsync(stream, uniqueFileName, videoFile.ContentType).ConfigureAwait(false);

        return result;
    }
}

