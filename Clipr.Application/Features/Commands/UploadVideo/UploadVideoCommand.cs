using MediatR;
using Microsoft.AspNetCore.Http; // Added

namespace Clipr.Application.Features.Commands.UploadVideo;

// Changed IRequest<Unit> to IRequest<string>
public class UploadVideoCommand : IRequest<string>
{
    public IFormFile VideoFile { get; set; } = null!; // Replaced properties
}
