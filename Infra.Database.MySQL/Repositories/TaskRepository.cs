using Domain.Task;
using Domain.Task.Repositories;

namespace Infra.Database.MySQL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly RequirementDbContext _context;

        public TaskRepository(RequirementDbContext context)
        {
            _context = context;
        }

        public TaskEntity? Get(string id)
        {
            return _context.Set<TaskEntity>().Find(id);
        }
    }
}
