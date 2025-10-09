using StudentAffairs.Application.Interfaces;

namespace StudentAffairs.Infrastructure;
public static class InfrastructureServiceRegisteration
{
    public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                 .EnableDetailedErrors()
                 .EnableSensitiveDataLogging()
                 .EnableServiceProviderCaching());
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

}
