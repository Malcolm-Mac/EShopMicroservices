using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
public static IServiceCollection AddInfrustructureServices(this IServiceCollection services, IConfiguration configuration){
    var connectionString = configuration.GetConnectionString("Database");
    /* services.AddDbContext<ApplicationDbContext>(Options =>
    Options.UseSqlServer(connectionString));

    services.AddScoped<IApplicationDbContext, ApplicationDbContext>(); */
    return services;
}
}
