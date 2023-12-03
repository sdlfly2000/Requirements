using Common.Core.DependencyInjection;
using Domain.UserRequirement;
using Domain.UserRequirement.Repositories;
using Microsoft.EntityFrameworkCore;

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
            return _context.UserRequirements
                .Include(ur => ur.UserStories)
                .FirstOrDefault(ur => EF.Property<string>(ur, "_id").Equals(id));
        }

        public string Update(UserRequirementEntity entity)
        {
            _context.UserRequirements.Update(entity);
            _context.SaveChanges();
            return entity.ID.Code;
        }
    }
}
