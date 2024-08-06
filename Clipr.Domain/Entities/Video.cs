using Clipr.Domain.Common;

namespace Clipr.Domain.Entities;

public class Video: EntityBase
{
    public int VideoId { get; set; }
    public string VideoName { get; set; } = null!;
    public string VideoDescription { get; set; } = null!;
    public string VideoType { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public string VideoThumbnailUrl { get; set; } = string.Empty;
    public string VideoTags { get; set; } = string.Empty;
    public VideoType VideoCategory { get; set; }  
}

public enum VideoType
{
    Sports,
    Entertainment,
    Travel,
    MusicVideo,
    Gaming,
    Education,
    Other
}
