using Clipr.Common.Domain.Abstractions;

namespace Clipr.Modules.Upload.Domain.Entities;

public class Video: Entity<Guid>
{
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
