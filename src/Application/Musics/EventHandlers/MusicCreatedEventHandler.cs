using MusicManagement.Domain.Events;
using Microsoft.Extensions.Logging;
using MediatR;

namespace MusicManagement.Application.Musics.EventHandlers;

public class MusicCreatedEventHandler : INotificationHandler<MusicCreatedEvent>
{
    private readonly ILogger<MusicCreatedEventHandler> _logger;

    public MusicCreatedEventHandler(ILogger<MusicCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(MusicCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Api Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
