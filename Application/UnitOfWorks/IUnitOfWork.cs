using Microsoft.EntityFrameworkCore.Storage;

namespace Application.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Commit();
        IDbContextTransaction BeginTran();
        int SaveAllChanges();
        void Rollback();
    }
}
