namespace Requirement.Common
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity? Get(string Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
