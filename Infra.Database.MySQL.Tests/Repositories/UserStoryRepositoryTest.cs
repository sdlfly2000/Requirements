using Domain.Task.Repositories;
using Domain.UserStory;
using Domain.UserStory.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Requirement.Test.Common;

namespace Infra.Database.MySQL.Tests.Repositories
{
    [TestClass]
    public class UserStoryRepositoryTest
    {
        private IServiceCollection _serviceCollection;

        [TestInitialize]
        public void Initialize()
        {
            _serviceCollection = ServiceContainer.CreateDefaultForUnitTest();
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_TaskId_When_Add_Then_taskAddedToUserStory()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var taskRepository = services.GetRequiredService<ITaskRepository>();
            var userStoryRepository = services.GetRequiredService<IUserStoryRepository>();

            var task = taskRepository.Get("caa386e0-d664-435f-b3e9-fe26cd17dea0");
            Assert.IsNotNull(task);
            var userStory = userStoryRepository.Get("d77c21b1-2cb8-4577-a6a2-6b973584f0aa");
            Assert.IsNotNull(userStory);

            userStory.AddTask(task);

            // Action
            var id = userStoryRepository.Update(userStory);

            // Asserts
            Assert.IsNotNull(id);
            Assert.AreEqual("d77c21b1-2cb8-4577-a6a2-6b973584f0aa", id);
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_When_Add_Then_UserStory_Return()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var userStoryRepository = services.GetRequiredService<IUserStoryRepository>();
            var ownerId = Guid.NewGuid();
            var userStory = UserStoryEntity.Create("UserStoryTitle", null, ownerId, TimeSpan.FromDays(10), ownerId);

            // Action
            var userStoryId = userStoryRepository.Add(userStory);

            // Asserts
            Assert.IsNotNull(userStoryId);
            Assert.AreEqual(userStory.ID.Code, userStoryId);
        }
    }
}
