using Ardalis.GuardClauses;
using MediatR;
using MusicManagement.Application.Common.Interfaces;
using MusicManagement.Domain.Events;

namespace MusicManagement.Application.Musics.Commands.Delete;

public record DeleteMusicCommand(int Id) : IRequest;

public class DeleteMusicCommandHandler : IRequestHandler<DeleteMusicCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteMusicCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteMusicCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Musics
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Musics.Remove(entity);

        entity.AddDomainEvent(new MusicDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
