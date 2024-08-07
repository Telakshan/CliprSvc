using Clipr.Domain.Entities;

namespace Clipr.Infrastructure.Contracts.Persistence;

public interface IVideoRepository: IAsyncRepository<Video>
{
    Task<IEnumerable<Video>> GetVideos();
}
