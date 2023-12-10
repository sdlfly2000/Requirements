using Application.Models;
using Domain.Task.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Requirement.Test.Common;

namespace Application.Test
{
    [TestClass]
    public class ApplicationServiceTest
    {


        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod, TestCategory(TestType.SystemTest)]
        public void Given_CreateTaskReqest_When_Create_Then_CreateTaskResponse_return_TaskExistInDB()
        {
            // Arrange
            var serviceCollection = ServiceContainer.CreateDefaultForUnitTest();
            using var services = serviceCollection.BuildServiceProvider();

            var owner = Guid.NewGuid();
            var createTaskRequest = new CreateTaskRequest
            { 
                Title = "Task Title",
                Description="Task Description",
                OwnerId = owner.ToString()
            };

            var applicationService = services.GetRequiredService<IApplicationService>();

            // Action
            var response = applicationService.Create(createTaskRequest).GetAwaiter().GetResult();
            Assert.IsNotNull(response);

            var taskRepository = services.GetRequiredService<ITaskRepository>();
            var task = taskRepository.Get(response.TaskId);

            // Assert
            Assert.IsNotNull(task);
            Assert.AreEqual(owner, task.OwnerId);
            Assert.AreEqual("Task Title", task.Title);
        }
    }
}