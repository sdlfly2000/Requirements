using Common.Core.DependencyInjection;
using Domain.UserStory;
using Domain.UserStory.Repositories;

namespace Infra.Database.MySQL.Repositories
{
    [ServiceLocate(typeof(IUserStoryRepository))]
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
            _context.SaveChanges();
            return id;
        }

        public UserStoryEntity? Get(string Id)
        {
            return _context.UserStories.Find(Id); ;
        }

        public string Update(UserStoryEntity entity)
        {
            var id = _context.UserStories.Update(entity).Entity.ID.Code;
            _context.SaveChanges();
            return id;
        }
    }
}
