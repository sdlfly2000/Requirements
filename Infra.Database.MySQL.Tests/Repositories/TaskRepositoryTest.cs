using Domain.Task;
using Domain.Task.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Requirement.Test.Common;

namespace Infra.Database.MySQL.Tests.Repositories
{
    [TestClass]
    public class TaskRepositoryTest
    {
        private IServiceCollection _serviceCollection;

        [TestInitialize]
        public void Initialize()
        {
            _serviceCollection = ServiceContainer.CreateDefaultForUnitTest();
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_NewTask_When_Add_Then_Task_Added()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var repository = services.GetRequiredService<ITaskRepository>();
            var title = "test title";
            var description = "Test Description";
            var ownerId = Guid.NewGuid();

            // Action
            var task = TaskEntity.Create(title, description, ownerId, TimeSpan.FromDays(10), ownerId);
            var id = repository.Add(task);

            // Asserts
            Assert.IsNotNull(id);
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_TaskId_When_Get_Then_Task_Return()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var repository = services.GetRequiredService<ITaskRepository>();
            var id = "caa386e0-d664-435f-b3e9-fe26cd17dea0";

            // Action
            var task = repository.Get(id);

            // Asserts
            Assert.IsNotNull(task);
            Assert.AreEqual(id, task.ID.Code);
        }
    }
}
