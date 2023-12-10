using Common.Core.DependencyInjection;
using Domain.UserStory;
using Domain.UserStory.Repositories;

namespace Infra.Database.MySQL.Repositories
{
    [ServiceLocate(typeof(IUserStoryRepository))]
    public class UserStoryRepository : Repository<UserStoryEntity>, IUserStoryRepository
    {
        private readonly RequirementDbContext _context;

        public UserStoryRepository(RequirementDbContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
