using Clipr.Modules.Upload.Domain.Common;

namespace Clipr.Modules.Upload.Domain.Entities;

public class Video: EntityBase<int>
{
    public int VideoId { get; set; }
    public Guid UserId { get; set; }
    public string VideoName { get; set; } = null!;
    public string VideoDescription { get; set; } = null!;
    public Uri? VideoUrl { get; set; }
    public Uri? VideoThumbnailUrl { get; set; }
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
