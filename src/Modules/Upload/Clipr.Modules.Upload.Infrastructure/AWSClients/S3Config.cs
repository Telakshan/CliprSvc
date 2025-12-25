namespace Clipr.Modules.Upload.Infrastructure.AWSClients;

public class S3Config
{
    public string? AwsAccessKeyId { get; set; }
    public string? AwsSecretAccessKey { get; set; }
    public string? Region { get; set; }
    public string? BucketName { get; set; }
}
