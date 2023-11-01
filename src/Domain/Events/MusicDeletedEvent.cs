namespace MusicManagement.Domain.Events;

public class MusicDeletedEvent : BaseEvent
{
    public MusicDeletedEvent(Music item)
    {
        Item = item;
    }

    public Music Item { get; }
}
