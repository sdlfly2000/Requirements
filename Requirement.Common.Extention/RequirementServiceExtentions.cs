using Infra.Database.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Requirement.Common.Extentions
{
    public static class RequirementServiceExtentions
    {
        public static IServiceCollection AddMySQLDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<RequirementDbContext>(
                options => options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly("Infra.Database.MySQL")));
        }

        public static IServiceCollection AddMSSQLDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<RequirementDbContext>(
                options => options.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly("Infra.Database.MySQL")));
        }
    }
}
