using MusicManagement.Application.Common.Interfaces;
using MusicManagement.Infrastructure.Identity;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.ConfigureAuthorizationPolicies();
        services.AddScoped<IUser, CurrentUser>();
        services.AddTransient<IIdentityService, IdentityService>();

        /* services.AddAuthorization(options =>
         options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));*/
        return services;
    }
}
