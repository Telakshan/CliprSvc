using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon;

namespace Clipr.Infrastructure.AwsClients
{
    public class S3ConfigOptions
    {
        public const string S3Config = "S3Config";
        public string? AwsAccessKeyId { get; set; }
        public string? AwsSecretAccessKey { get; set; }
        public string? Region { get; set; }
        public string? BucketName { get; set; }
    }

    public class AmazonS3StorageClient : IDisposable
    {
        private readonly IAmazonS3 _s3Client;
        private readonly S3ConfigOptions _s3Config;

        public AmazonS3StorageClient(IOptions<S3ConfigOptions> s3ConfigOptions)
        {
            _s3Config = s3ConfigOptions.Value;

            if (string.IsNullOrEmpty(_s3Config.AwsAccessKeyId) || string.IsNullOrEmpty(_s3Config.AwsSecretAccessKey))
            {
                 _s3Client = new AmazonS3Client(RegionEndpoint.GetBySystemName(_s3Config.Region));
            }
            else
            {
                var credentials = new BasicAWSCredentials(_s3Config.AwsAccessKeyId, _s3Config.AwsSecretAccessKey);
                _s3Client = new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(_s3Config.Region));
            }
        }

        public async Task<string> UploadFileAsync(Stream inputStream, string key, string contentType)
        {
            if (string.IsNullOrEmpty(_s3Config.BucketName))
            {
                throw new InvalidOperationException("S3 BucketName is not configured.");
            }

            var putRequest = new PutObjectRequest
            {
                BucketName = _s3Config.BucketName,
                Key = key,
                InputStream = inputStream,
                ContentType = contentType,
                CannedACL = S3CannedACL.PublicRead
            };

            PutObjectResponse response = await _s3Client.PutObjectAsync(putRequest);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return $"https://{_s3Config.BucketName}.s3.{_s3Config.Region}.amazonaws.com/{key}";
            }
            else
            {
                throw new Exception($"Error uploading file to S3. HttpStatusCode: {response.HttpStatusCode}");
            }
        }

        public void Dispose()
        {
            _s3Client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
