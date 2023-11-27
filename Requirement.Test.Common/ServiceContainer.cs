using Common.Core.DependencyInjection;
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
            container.AddMySQLDatabase("server=192.168.71.151;database=SimpleDashboard;uid=sdlfly2000;password=sdl@1215;");
            container.RegisterDomain("Application.Services", "Domain.Services", "Infra.Database.MySQL");
            return container;
        }
    }
}
