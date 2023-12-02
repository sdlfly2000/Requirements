using Common.Core.DependencyInjection;
using Domain.UserRequirement.Repositories;
using Domain.UserStory;

namespace Infra.Database.MySQL.Repositories
{
    [ServiceLocate(typeof(IUserRequirementRepository))]
    public class UserRequirementRepository : IUserRequirementRepository
    {
        private readonly RequirementDbContext _context;

        public UserRequirementRepository(RequirementDbContext context)
        {
            _context = context;
        }

        public string Add(UserRequirementEntity entity)
        {
            _context.UserRequirements.Add(entity);
            _context.SaveChanges();
            return entity.ID.Code;
        }

        public UserRequirementEntity? Get(string id)
        {
            return _context.UserRequirements.Find(id);
        }

        public string Update(UserRequirementEntity entity)
        {
            _context.UserRequirements.Update(entity);
            _context.SaveChanges();
            return entity.ID.Code;
        }
    }
}
