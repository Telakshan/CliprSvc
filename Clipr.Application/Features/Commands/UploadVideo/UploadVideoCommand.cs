using MediatR;
using Microsoft.AspNetCore.Http;

namespace Clipr.Application.Features.Commands.UploadVideo
{
    public class UploadVideoCommand : IRequest<string>
    {
        public IFormFile VideoFile { get; set; } = null!;
    }
}
