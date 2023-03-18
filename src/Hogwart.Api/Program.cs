using Hogwart.Api.Web;
using Hogwart.Infrastructure.DependencyInjection;

WebApplication
    .CreateBuilder(args)
    .ConfigureDependencyInjection()
    .Build()
    .ConfigureWebApplication()
    .Run();