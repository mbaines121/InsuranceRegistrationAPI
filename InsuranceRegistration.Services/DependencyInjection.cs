using Microsoft.Extensions.DependencyInjection;

namespace InsuranceRegistration.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPolicyHolderService, PolicyHolderService>();

        return services;
    }
}
