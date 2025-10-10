
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TI_Net_2025_DemoEntity.ToolBoxEF.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }


        public bool Any(Func<TEntity, bool> predicate)
        {
            return _entities.Any(predicate);
        }

        public long Count(Func<TEntity, bool>? predicate = null)
        {
            if(predicate == null)
            {
                return _entities.Count();
            }

            return _entities.Where(predicate).Count();
        }

        public bool Delete(TEntity entity)
        {
            _entities.Remove(entity);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<TEntity> FindMany(Func<TEntity, bool>? predicate = null)
        {
            return predicate is null ? _entities : _entities.Where(predicate);
        }

        public TEntity? FindOne(params object[] ids)
        {
            return _entities.Find(ids);
        }

        public TEntity? FindOne(Func<TEntity, bool> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            EntityEntry<TEntity> result = _entities.Add(entity);

            _context.SaveChanges();

            return result.Entity;
        }

        public void Add(List<TEntity> entities)
        {
            _entities.AddRange(entities);
            _context.SaveChanges();
        }

        public bool Update(TEntity entity)
        {
            _entities.Update(entity);

            return _context.SaveChanges() == 1;
        }
    }
}
