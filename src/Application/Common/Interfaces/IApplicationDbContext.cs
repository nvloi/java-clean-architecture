using Microsoft.EntityFrameworkCore;
using MusicManagement.Domain.Entities;

namespace MusicManagement.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Music> Musics { get; }

    DbSet<Album> Albums { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
