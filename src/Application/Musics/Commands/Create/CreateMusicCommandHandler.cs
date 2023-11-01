using MusicManagement.Application.Common.Interfaces;
using MusicManagement.Domain.Entities;
using MusicManagement.Domain.Events;

namespace MusicManagement.Application.Musics.Commands.Create;

public record CreateMusicCommand : IRequest<int>
{
    public int AlbumId { get; init; }

    public string? Title { get; init; }
}

public class CreateMusicCommandHandler : IRequestHandler<CreateMusicCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMusicCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMusicCommand request, CancellationToken cancellationToken)
    {
        var entity = new Music
        {
            AlbumId = request.AlbumId,
            Title = request.Title
        };

        entity.AddDomainEvent(new MusicCreatedEvent(entity));

        _context.Musics.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
