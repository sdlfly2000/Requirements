using Domain.Task.Repositories;
using Domain.UserRequirement;
using Domain.UserRequirement.Repositories;
using Domain.UserStory.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Requirement.Test.Common;

namespace Infra.Database.MySQL.Tests.Repositories
{
    [TestClass]
    public class UserRequirementRepositoryTest
    {
        private IServiceCollection _serviceCollection;

        [TestInitialize]
        public void Initialize()
        {
            _serviceCollection = ServiceContainer.CreateDefaultForUnitTest();
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_UserStoryId_When_Add_Then_UserStoryAddedToUserRequirement()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var userRequirementRepository = services.GetRequiredService<IUserRequirementRepository>();
            var userStoryRepository = services.GetRequiredService<IUserStoryRepository>();

            var userRequirement = userRequirementRepository.Get("b8a443de-1c32-490a-8584-8c3437de8431");
            Assert.IsNotNull(userRequirement);
            var userStory = userStoryRepository.Get("d77c21b1-2cb8-4577-a6a2-6b973584f0aa");
            Assert.IsNotNull(userStory);

            userRequirement.AddUserStory(userStory);

            // Action
            var id = userRequirementRepository.Update(userRequirement);

            // Asserts
            Assert.IsNotNull(id);
            Assert.AreEqual("b8a443de-1c32-490a-8584-8c3437de8431", id);
        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_When_Add_Then_UserRequirement_Return()
        {
            // Arrange
            using var services = _serviceCollection.BuildServiceProvider();
            var userRequirementRepository = services.GetRequiredService<IUserRequirementRepository>();
            var ownerId = Guid.NewGuid();
            var userRequirement = UserRequirementEntity.Create("UserRequirementTitle", null, ownerId, TimeSpan.FromDays(10), ownerId);

            // Action
            var userRequirementId = userRequirementRepository.Add(userRequirement);

            // Asserts
            Assert.IsNotNull(userRequirementId);
            Assert.AreEqual(userRequirement.ID.Code, userRequirementId);
        }
    }
}
