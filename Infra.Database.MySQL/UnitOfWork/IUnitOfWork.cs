using Domain.Task.Repositories;
using Domain.UserRequirement.Repositories;
using Domain.UserStory.Repositories;

namespace Infra.Database.MySQL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITaskRepository TaskRepository { get; }
        IUserStoryRepository UserStoryRepository { get; }
        IUserRequirementRepository UserRequirementRepository { get; }

        void Commit();
        void BeginTran();
    }
}
