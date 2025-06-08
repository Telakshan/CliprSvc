using Clipr.Infrastructure.Contracts.Infrastructure;
using Clipr.Infrastructure.AwsClients; 
using Microsoft.AspNetCore.Http;      
using System;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text; 

namespace Clipr.Infrastructure.Upload
{
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

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(videoFile.FileName)}";

            using var stream = videoFile.OpenReadStream();
            return await _s3Client.UploadFileAsync(stream, uniqueFileName, videoFile.ContentType);
        }
    }
}
