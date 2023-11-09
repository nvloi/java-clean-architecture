using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MusicManagement.Infrastructure.Identity;

namespace MusicManagement.Application.Musics.Commands.Update
{
    public class UpdateMusicRequirement : IAuthorizationRequirement
    {
        public UpdateMusicRequirement()
        {
        }
    }

    public class UpdateMusicAuthorizationHandler : AuthorizationHandler<UpdateMusicRequirement>
    {
        private readonly ILogger<UpdateMusicAuthorizationHandler> _logger;
        private readonly UserManager<ApplicationUser> _userService;

        public UpdateMusicAuthorizationHandler(UserManager<ApplicationUser> userService, ILogger<UpdateMusicAuthorizationHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UpdateMusicRequirement requirement)
        {
            var resourceHttpContext = context.Resource as DefaultHttpContext;
            string controller = resourceHttpContext?.GetRouteValue("controller")?.ToString() ?? "";
            string action = resourceHttpContext?.GetRouteValue("action")?.ToString() ?? "";
            if (controller == "Music" && action == "Update")
            {
                _logger.LogInformation("UpdateMusicRequirement successed");
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

}
