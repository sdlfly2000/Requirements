using Common.Core.DependencyInjection;
using Domain.Task;
using Domain.Task.Repositories;

namespace Infra.Database.MySQL.Repositories
{
    [ServiceLocate(typeof(ITaskRepository))]
    public class TaskRepository : ITaskRepository
    {
        private readonly RequirementDbContext _context;

        public TaskRepository(RequirementDbContext context)
        {
            _context = context;
        }

        public string Add(TaskEntity entity)
        {
            _context.Tasks.Add(entity);
            return entity.ID.Code;
        }

        public TaskEntity? Get(string id)
        {
            return _context.Tasks.Find(id);
        }

        public string Update(TaskEntity entity)
        {
            _context.Tasks.Update(entity);
            return entity.ID.Code;
        }
    }
}
