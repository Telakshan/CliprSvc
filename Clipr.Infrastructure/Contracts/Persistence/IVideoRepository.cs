using Clipr.Domain.Entities;

namespace Clipr.Infrastructure.Contracts.Persistence;

public interface IVideoRepository: IAsyncRepository<Video, int>
{
    Task<IEnumerable<Video>> GetVideosByUsername(string userName);
}
