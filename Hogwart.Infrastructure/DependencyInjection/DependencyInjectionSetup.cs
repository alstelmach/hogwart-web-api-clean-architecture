using Hogwart.Application.Contracts;
using Hogwart.Domain.Repositories;
using Hogwart.Domain.Services;
using Hogwart.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hogwart.Infrastructure.DependencyInjection;

public static class DependencyInjectionSetup
{
    public static WebApplicationBuilder ConfigureDependencyInjection(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder
            .Services
            .AddMediatR(config =>
                config.RegisterServicesFromAssemblies(typeof(GetHouseQuery).Assembly))
            .AddScoped<ISortingDomainService, SortingDomainService>()
            .AddScoped<IHouseRepository, HouseRepository>()
            .AddControllers()
            .Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return webApplicationBuilder;
    }
}
