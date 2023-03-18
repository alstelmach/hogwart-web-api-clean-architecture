using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hogwart.Infrastructure.DependencyInjection;

public static class DependencyInjectionSetup
{
    public static WebApplicationBuilder ConfigureDependencyInjection(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder
            .Services
            .AddControllers()
            .Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return webApplicationBuilder;
    }
}
