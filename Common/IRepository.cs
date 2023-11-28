namespace Requirement.Common
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity? Get(string Id);
        string Add(TEntity entity);
        string Update(TEntity entity);
    }
}
