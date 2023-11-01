namespace MusicManagement.Domain.Events;

public class MusicCompletedEvent : BaseEvent
{
    public MusicCompletedEvent(Music item)
    {
        Item = item;
    }

    public Music Item { get; }
}
