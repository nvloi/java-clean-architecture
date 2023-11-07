using MusicManagement.Infrastructure.Identity;
using MusicManagement.Web.Extensions.Endpoints;

namespace MusicManagement.Web.Controllers;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
