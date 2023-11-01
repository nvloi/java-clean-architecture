namespace MusicManagement.Domain.Entities;

public class Album : BaseAuditableEntity
{
    public string? Title { get; set; }
    public IList<Music> Musics { get; private set; } = new List<Music>();
}
