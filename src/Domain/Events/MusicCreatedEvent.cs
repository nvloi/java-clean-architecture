namespace MusicManagement.Domain.Events;

public class MusicCreatedEvent : BaseEvent
{
    public MusicCreatedEvent(Music item)
    {
        Item = item;
    }

    public Music Item { get; }
}
