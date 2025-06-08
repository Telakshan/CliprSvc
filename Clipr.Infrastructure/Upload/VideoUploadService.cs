using Clipr.Infrastructure.Contracts.Infrastructure;
using Clipr.Infrastructure.AwsClients; // For AmazonS3StorageClient
using Microsoft.AspNetCore.Http;      // For IFormFile
using System;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography; // For unique name generation (alternative to Guid)
using System.Text; // For unique name generation

namespace Clipr.Infrastructure.Upload
{
    public class VideoUploadService : IVideoUploadService
    {
        private readonly AmazonS3StorageClient _s3StorageClient;

        public VideoUploadService(AmazonS3StorageClient s3StorageClient)
        {
            _s3StorageClient = s3StorageClient ?? throw new ArgumentNullException(nameof(s3StorageClient));
        }

        public async Task<string> UploadVideoAsync(IFormFile videoFile)
        {
            if (videoFile == null || videoFile.Length == 0)
            {
                throw new ArgumentException("Video file cannot be null or empty.", nameof(videoFile));
            }

            var fileExtension = Path.GetExtension(videoFile.FileName);
            // Generate a more unique name, e.g., using a timestamp and a short hash or a GUID
            var uniqueFileName = $"{Guid.NewGuid().ToString().Substring(0, 13)}{fileExtension}";

            await using var stream = videoFile.OpenReadStream();

            // It's good practice to ensure the key (uniqueFileName) is URL-safe.
            // GUIDs and typical extensions are generally fine.
            var videoUrl = await _s3StorageClient.UploadFileAsync(stream, uniqueFileName, videoFile.ContentType);

            return videoUrl;
        }
    }
}
