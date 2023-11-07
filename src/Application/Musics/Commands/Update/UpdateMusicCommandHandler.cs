using Ardalis.GuardClauses;
using MediatR;
using MusicManagement.Application.Common.Interfaces;

namespace MusicManagement.Application.Musics.Commands.Update;

public record UpdateMusicCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateMusicCommandHandler : IRequestHandler<UpdateMusicCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMusicCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Musics
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
