using Common.Core.DependencyInjection;
using Domain.Task;
using Domain.Task.Repositories;

namespace Infra.Database.MySQL.Repositories
{
    [ServiceLocate(typeof(ITaskRepository))]
    public class TaskRepository : Repository<TaskEntity>, ITaskRepository
    {
        private readonly RequirementDbContext _context;

        public TaskRepository(RequirementDbContext context)
            :base(context) 
        {
            _context = context;
        }

    }
}
