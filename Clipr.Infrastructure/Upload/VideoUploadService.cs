using Clipr.Infrastructure.AwsClients;
using Clipr.Infrastructure.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;

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
            
            //ACTUAL CODE
            /*
            using var stream = videoFile.OpenReadStream();

            return await _s3Client.UploadFileAsync(stream, uniqueFileName, videoFile.ContentType);*/

            //TEST CODE BEGINS
            var folderName = "test-uploads";
            var filePath = Path.Combine(folderName, uniqueFileName);
            Directory.CreateDirectory(folderName);

            using var stream = videoFile.OpenReadStream();
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(fileStream);
            //TEST CODE ENDS
            return filePath;
        }
    }
}
