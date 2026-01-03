using Clipr.Modules.Upload.Domain.Entities;
using Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;
using Clipr.Modules.Upload.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clipr.Modules.Upload.Infrastructure.Repository;

public class VideoRepository : RepositoryBase<Video, int>, IVideoRepository
{
    public VideoRepository(CliprDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Video>> GetVideosByUsername(string userName)
    {
        return await _dbContext.Videos
            .Where(o => o.User.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)).ToListAsync().ConfigureAwait(false);
    }
} 
