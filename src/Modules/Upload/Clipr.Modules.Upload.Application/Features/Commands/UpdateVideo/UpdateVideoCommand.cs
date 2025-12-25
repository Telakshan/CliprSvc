namespace Clipr.Modules.Upload.Application.Features.Commands.UpdateVideo;

public class UpdateVideoCommand
{
    public int VideoId { get; set; }
    public string VideoName { get; set; } = null!;
    public string VideoDescription { get; set; } = null!;
    public string VideoType { get; set; } = string.Empty;
    public Uri VideoUrl { get; set; } 
    public Uri VideoThumbnailUrl { get; set; }
    public string VideoTags { get; set; } = string.Empty;
    public string VideoCategory { get; set; } = string.Empty;
}
