using Application;
using Application.UnitOfWorks;
using Common.Core.DependencyInjection;
using Infra.Database.MySQL;
using Microsoft.Extensions.DependencyInjection;
using Requirement.Common.Extentions;

namespace Requirement.Test.Common
{
    public static class ServiceContainer
    {
        public static IServiceCollection CreateDefaultForUnitTest()
        {
            var container = new ServiceCollection();

            container.AddMemoryCache();
            container.AddLogging();
            container.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationService).Assembly));
            container.AddMySQLDatabase("server=192.168.71.151;database=Requirement;uid=sdlfly2000;password=sdl@1215;");
            container.RegisterDomain("Application","Domain","Infra.Database.MySQL");
            container.AddScoped<IRequirementUnitOfWork>(sp => sp.GetRequiredService<RequirementDbContext>());
            return container;
        }
    }
}
