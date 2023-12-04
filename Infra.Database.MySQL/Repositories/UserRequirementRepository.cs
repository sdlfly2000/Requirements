using Domain.UserRequirement;
using Domain.UserRequirement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySQL.Repositories
{
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
            return entity.ID.Code;
        }

        public UserRequirementEntity? Get(string id)
        {
            return _context.UserRequirements
                .Where(ur => EF.Property<string>(ur, "_id").Equals(id))
                .Include(ur => ur.UserStories)
                .First();
        }

        public string Update(UserRequirementEntity entity)
        {
            _context.UserRequirements.Update(entity);
            return entity.ID.Code;
        }
    }
}
