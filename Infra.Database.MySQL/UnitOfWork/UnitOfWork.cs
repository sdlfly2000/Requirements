using Common.Core.DependencyInjection;
using Domain.Task.Repositories;
using Domain.UserRequirement.Repositories;
using Domain.UserStory.Repositories;
using Infra.Database.MySQL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Database.MySQL.UnitOfWork
{
    [ServiceLocate(typeof(IUnitOfWork))]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITaskRepository _taskRespoistory;
        private readonly IUserStoryRepository _userStoryRepository;
        private readonly IUserRequirementRepository _userRequirementRepository;
        private readonly RequirementDbContext _context;

        private IDbContextTransaction? _transaction;

        public UnitOfWork(RequirementDbContext context)
        {
            _taskRespoistory = new TaskRepository(context);
            _userStoryRepository = new UserStoryRepository(context);
            _userRequirementRepository = new UserRequirementRepository(context);
            _context = context;
        }

        public ITaskRepository TaskRepository { get => _taskRespoistory; }
        public IUserStoryRepository UserStoryRepository { get => _userStoryRepository; }
        public IUserRequirementRepository UserRequirementRepository { get => _userRequirementRepository; }

        public void Commit()
        {
            if(_transaction == null)
            {
                return;
            }

            _context.SaveChanges();
            _transaction.Commit();
        }

        public void BeginTran()
        {
            _transaction = _context.Database.BeginTransaction();
        }
    }
}
