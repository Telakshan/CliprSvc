using Clipr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipr.Infrastructure.Contracts.Persistence;

public interface IOrderRepository: IAsyncRepository<Video>
{
    Task<IEnumerable<Video>> GetVideos();
}
