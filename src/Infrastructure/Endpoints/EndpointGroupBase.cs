using Microsoft.AspNetCore.Builder;

namespace MusicManagement.Infrastructure.Endpoints;

public abstract class EndpointGroupBase
{
    public abstract void Map(WebApplication app);
}
