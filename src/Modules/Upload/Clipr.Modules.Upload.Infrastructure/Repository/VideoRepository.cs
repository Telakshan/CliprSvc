using Clipr.Modules.Upload.Domain.Entities;
using Clipr.Modules.Upload.Infrastructure.Contracts.Persistence;
using Clipr.Modules.Upload.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clipr.Modules.Upload.Infrastructure.Repository;

public class VideoRepository : RepositoryBase<Video, Guid>, IVideoRepository
{
    public VideoRepository(CliprDbContext dbContext) : base(dbContext)
    {
    }

    public Task<IEnumerable<Video>> GetVideosByUsername(string userName)
    {
        throw new NotImplementedException();
    }
} 
