using Common.Core.DependencyInjection;
using Domain.UserRequirement;
using Domain.UserRequirement.Repositories;

namespace Infra.Database.MySQL.Repositories
{
    [ServiceLocate(typeof(IUserRequirementRepository))]
    public class UserRequirementRepository : Repository<UserRequirementEntity>, IUserRequirementRepository
    {
        private readonly RequirementDbContext _context;

        public UserRequirementRepository(RequirementDbContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
