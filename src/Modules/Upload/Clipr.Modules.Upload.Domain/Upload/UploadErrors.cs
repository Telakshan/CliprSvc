using Clipr.Modules.Upload.Domain.Abstractions;

namespace Clipr.Modules.Upload.Domain.Upload;

public static class UploadErrors
{
    public static readonly Error UploadFailed = Error.Problem(
        code: "UploadFailed",
        description: "The upload process failed.");
}
