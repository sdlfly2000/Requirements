using Domain.Task.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Requirement.Test.Common;

namespace Infra.Database.MySQL.Tests.Repositories
{
    [TestClass]
    public class TaskRepositoryTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_TaskId_When_Get_Then_Task_Return()
        {
            // Arrange
            var serviceCollection = ServiceContainer.CreateDefaultForUnitTest();
            using var services = serviceCollection.BuildServiceProvider();
            var repository = services.GetRequiredService<ITaskRepository>();
            var id = "a0210fc2-6b2f-11ee-bd08-00262da8807c";

            // Action
            var task = repository.Get(id);

            // Asserts
            Assert.IsNotNull(task);
            Assert.AreEqual(id, task.ID.Code);
        }
    }
}
