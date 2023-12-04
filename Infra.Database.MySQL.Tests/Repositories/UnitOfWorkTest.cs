using Domain.Task;
using Domain.Task.Repositories;
using Domain.UserRequirement;
using Domain.UserStory;
using Domain.UserStory.Repositories;
using Infra.Database.MySQL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Requirement.Test.Common;
using System.Threading.Tasks;

namespace Infra.Database.MySQL.Tests.Repositories
{
    [TestClass]
    public class UnitOfWorkTest
    {
        private IServiceCollection _serviceCollection;

        [TestInitialize]
        public void Initialize()
        {
            _serviceCollection = ServiceContainer.CreateDefaultForUnitTest();
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_When_Add_Then_taskAddedToDatabase()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var uow = services.GetRequiredService<IUnitOfWork>();
            var task = TaskEntity.Create("Task Title", "Task Description", Guid.NewGuid(), null, null);

            // Action
            uow.BeginTran();
            var id = uow.TaskRepository.Add(task);
            uow.Commit();

            // Asserts
            Assert.IsNotNull(id);
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_taskId_When_Add_Then_UserStory_Return()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var uow = services.GetRequiredService<IUnitOfWork>();

            var ownerId = Guid.NewGuid();
            var userStory = UserStoryEntity.Create("UserStoryTitle", null, ownerId, TimeSpan.FromDays(10), ownerId);
            var task = uow.TaskRepository.Get("fd721061-349d-4659-960c-248659f717a2");
            Assert.IsNotNull(task);
            userStory.AddTask(task);

            // Action
            uow.BeginTran();
            var userStoryId = uow.UserStoryRepository.Add(userStory);
            uow.Commit();

            // Asserts
            Assert.IsNotNull(userStoryId);
        }


        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_UserStoryId_When_Add_Then_UserRequirement_Return()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var uow = services.GetRequiredService<IUnitOfWork>();

            var ownerId = Guid.NewGuid();
            var userRequirementStory = UserRequirementEntity.Create("UserRequirementTitle", null, ownerId, TimeSpan.FromDays(10), ownerId);
            var userStory = uow.UserStoryRepository.Get("30e8d015-29d6-4d1c-bb10-fdb66d1cc415");
            Assert.IsNotNull(userStory);
            userRequirementStory.AddUserStory(userStory);

            // Action
            uow.BeginTran();
            var userRequirementId = uow.UserRequirementRepository.Add(userRequirementStory);
            uow.Commit();

            // Asserts
            Assert.IsNotNull(userRequirementId);
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_UserRequirementId_When_Load_Then_UserRequirement_Return()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var uow = services.GetRequiredService<IUnitOfWork>();
            
            // Action
            var userRequirement = uow.UserRequirementRepository.Get("28c2635f-a5cd-4893-a95c-786a6db2e2d4");

            // Asserts
            Assert.IsNotNull(userRequirement);
            Assert.IsTrue(userRequirement.UserStories.Any());
        }
    }
}
