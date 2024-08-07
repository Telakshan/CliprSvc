using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipr.Application.Features.Commands.UpdateVideo;

public class UpdateVideoCommand
{
    public int VideoId { get; set; }
    public string VideoName { get; set; } = null!;
    public string VideoDescription { get; set; } = null!;
    public string VideoType { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public string VideoThumbnailUrl { get; set; } = string.Empty;
    public string VideoTags { get; set; } = string.Empty;
    public string VideoCategory { get; set; } = string.Empty;
}
