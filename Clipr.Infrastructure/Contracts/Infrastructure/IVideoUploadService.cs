using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Clipr.Infrastructure.Contracts.Infrastructure;

public interface IVideoUploadService
{
    // Modify this line
    Task<string> UploadVideoAsync(IFormFile videoFile);
}
