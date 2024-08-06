using Clipr.Domain.Entities;
using Clipr.Infrastructure.Contracts.Persistence;
using Clipr.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clipr.Infrastructure.Repository;

public class VideoRepository : RepositoryBase<Video>, IVideoRepository
{
    public VideoRepository(CliprDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Video>> GetVideos()
    {
        var videoList = await _dbContext.Videos.ToListAsync();

        return videoList;
    }
}
