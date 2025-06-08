using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Clipr.Infrastructure.AWSClients;
using Microsoft.Extensions.Options;

namespace Clipr.Infrastructure.AwsClients
{


    public class AmazonS3StorageClient : IDisposable
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IOptions<S3Config> _s3Config;

        public AmazonS3StorageClient(IOptions<S3Config> s3ConfigOptions)
        {
            _s3Config = s3ConfigOptions;

            if (string.IsNullOrEmpty(_s3Config.Value.AwsAccessKeyId) || string.IsNullOrEmpty(_s3Config.Value.AwsSecretAccessKey))
            {
                _s3Client = new AmazonS3Client(RegionEndpoint.GetBySystemName(_s3Config.Value.Region));
            }
            else
            {
                var credentials = new BasicAWSCredentials(_s3Config.Value.AwsAccessKeyId, _s3Config.Value.AwsSecretAccessKey);
                _s3Client = new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(_s3Config.Value.Region));
            }
        }

        public async Task<string> UploadFileAsync(Stream inputStream, string key, string contentType)
        {
            if (string.IsNullOrEmpty(_s3Config.Value.BucketName))
            {
                throw new InvalidOperationException("S3 BucketName is not configured.");
            }

            var putRequest = new PutObjectRequest
            {
                BucketName = _s3Config.Value.BucketName,
                Key = key,
                InputStream = inputStream,
                ContentType = contentType,
                CannedACL = S3CannedACL.PublicRead
            };

            PutObjectResponse response = await _s3Client.PutObjectAsync(putRequest);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return $"https://{_s3Config.Value.BucketName}.s3.{_s3Config.Value.Region}.amazonaws.com/{key}";
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
