using Clipr.Common.Domain.Abstractions;
using Clipr.Modules.Upload.Domain.Abstractions;
using Clipr.Modules.Upload.Domain.Entities;

namespace Clipr.Modules.Upload.Domain.Upload;

public interface IVideoRepository : IAsyncRepository<Video, int>
{
    Task<IEnumerable<Video>> GetVideosByUsername(string userName);
}
