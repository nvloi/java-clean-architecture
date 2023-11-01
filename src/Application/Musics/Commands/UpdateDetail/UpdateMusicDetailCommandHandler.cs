using MusicManagement.Application.Common.Interfaces;

namespace MusicManagement.Application.Musics.Commands.Update;

public record UpdateMusicDetailCommand : IRequest
{
    public int Id { get; init; }

    public int AlbumId { get; init; }
}

public class UpdateMusicDetailCommandHandler : IRequestHandler<UpdateMusicDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMusicDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMusicDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Musics
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.AlbumId = request.AlbumId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
