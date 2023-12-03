namespace Infra.Database.MySQL.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
