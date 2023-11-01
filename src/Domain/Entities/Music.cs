namespace MusicManagement.Domain.Entities;

public class Music : BaseAuditableEntity
{
    public string? Title { get; set; }
    public int? AlbumId { get; set; }
    public Album Album { get; set; } = null!;
}
