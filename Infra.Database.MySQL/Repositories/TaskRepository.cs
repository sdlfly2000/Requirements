using Common.Core.DependencyInjection;
using Domain.Task;
using Domain.Task.Repositories;
using Microsoft.EntityFrameworkCore;

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
            GetSet().Add(entity);
            return entity.ID.Code;
        }

        public TaskEntity? Get(string id)
        {
            return GetSet().Find(id);
        }

        public string Update(TaskEntity entity)
        {
            GetSet().Update(entity);
            return entity.ID.Code;
        }

        #region

        private DbSet<TaskEntity> GetSet()
        {
            return _context.Set<TaskEntity>();
        }

        #endregion
    }
}
