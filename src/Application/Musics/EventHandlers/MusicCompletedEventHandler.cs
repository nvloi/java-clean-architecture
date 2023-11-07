using MusicManagement.Domain.Events;
using Microsoft.Extensions.Logging;
using MediatR;

namespace MusicManagement.Application.Musics.EventHandlers;

public class MusicCompletedEventHandler : INotificationHandler<MusicCompletedEvent>
{
    private readonly ILogger<MusicCompletedEventHandler> _logger;

    public MusicCompletedEventHandler(ILogger<MusicCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(MusicCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Api Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
