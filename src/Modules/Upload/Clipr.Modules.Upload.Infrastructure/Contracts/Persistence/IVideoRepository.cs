using Clipr.Modules.Upload.Domain.Entities;

namespace Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;

public interface IVideoRepository: IAsyncRepository<Video, Guid>
{
    Task<IEnumerable<Video>> GetVideosByUsername(string userName);
}
