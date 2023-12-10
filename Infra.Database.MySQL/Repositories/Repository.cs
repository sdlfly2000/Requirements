using Microsoft.EntityFrameworkCore;
using Requirement.Common;

namespace Infra.Database.MySQL.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public virtual TEntity? Get(string Id)
    {
        return _context.Set<TEntity>().Find(Id);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
}
