using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MusicManagement.Application.Musics.Commands.Update;

namespace MusicManagement.Infrastructure.Identity
{
    public static class AuthorizationConfig
    {
        public static void ConfigureAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ViewMusic", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.RequireAssertion(context =>
                        context.User.Claims.Any(c => c.Type == "permissions" && c.Value == "music.view")
                    );
                });

                options.AddPolicy("EditMusic", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.RequireAssertion(context =>
                        context.User.Claims.Any(c => c.Type == "permissions" && c.Value == "music.view")
                    );
                    policyBuilder.Requirements.Add(new UpdateMusicRequirement());
                });

                options.AddPolicy("ViewRole", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    /* policyBuilder.RequireAssertion(context => context.User.IsInRole(RoleName.SuperAdmin) ||
                         context.User.Claims.Any(c => c.Type == "permissions" && c.Value == "role.view"));*/

                });

                options.AddPolicy("EditRole", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    /* policyBuilder.RequireAssertion(context => context.User.IsInRole(RoleName.SuperAdmin) ||
                        context.User.Claims.Any(c => c.Type == "permissions" && c.Value == "role.edit-permission"));*/
                });

                options.AddPolicy("ViewPermission", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    /* policyBuilder.RequireAssertion(context => context.User.IsInRole(RoleName.SuperAdmin) ||
                        context.User.Claims.Any(c => c.Type == "permissions" && c.Value == "role.view-permission"));*/
                });
            });

            services.AddTransient<IAuthorizationHandler, UpdateMusicAuthorizationHandler>();
        }
    }
}