using Clipr.Domain.Common;

namespace Clipr.Domain.Entities;

public class Video: EntityBase<int>
{
    public int VideoId { get; set; }
    public Guid UserId { get; set; }
    public string VideoName { get; set; } = null!;
    public string VideoDescription { get; set; } = null!;
    public string VideoType { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public string VideoThumbnailUrl { get; set; } = string.Empty;
    public string VideoTags { get; set; } = string.Empty;
    public VideoType VideoCategory { get; set; }
    public int ViewCount { get; set; } 
    public int LikesCount { get; set; }
    public int DislikesCount { get; set; }
    public DateTime UploadedAt { get; set; }
    public DateTime PublishedAt { get; set; }
    public VideoStatus Status { get; set; }
    public virtual User User { get; set; } = new();
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

public enum VideoStatus
{
    Draft,
    Published,
    Unlisted,
    Private,
    Deleted
}
