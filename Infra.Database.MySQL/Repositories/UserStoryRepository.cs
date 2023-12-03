using Common.Core.DependencyInjection;
using Domain.UserStory;
using Domain.UserStory.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySQL.Repositories
{
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly RequirementDbContext _context;

        public UserStoryRepository(RequirementDbContext context)
        {
            _context = context;
        }

        public string Add(UserStoryEntity entity)
        {
            var id = _context.UserStories.Add(entity)
                .Entity.ID.Code;
            return id;
        }

        public UserStoryEntity? Get(string Id)
        {
            return _context.UserStories
                .Where(us => EF.Property<string>(us, "_id").Equals(Id))
                .Include(us => us.Tasks)
                .First();
        }

        public string Update(UserStoryEntity entity)
        {
            var id = _context.UserStories.Update(entity).Entity.ID.Code;
            return id;
        }
    }
}
