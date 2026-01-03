using Microsoft.AspNetCore.Routing;

namespace Clipr.Modules.Upload.Presentation.Upload;

public static class UploadEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateUpload.MapEnpoint(app);
    }
}
