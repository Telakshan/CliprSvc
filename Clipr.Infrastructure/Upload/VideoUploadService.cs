using Clipr.Infrastructure.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipr.Infrastructure.Upload;

public class VideoUploadService : IVideoUploadService
{
    public Task<string> UploadVideoAsync(string videoPath)
    {
        throw new NotImplementedException();
    }
}
