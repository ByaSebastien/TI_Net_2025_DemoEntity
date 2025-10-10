namespace TI_Net_2025_DemoEntity.ToolBoxEF.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> FindMany(Func<TEntity,bool>? predicate = null);
        TEntity? FindOne(params object[] ids);
        TEntity? FindOne(Func<TEntity, bool> predicate);
        TEntity Add(TEntity entity);
        void Add(List<TEntity> entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Any(Func<TEntity,bool> predicate);
        long Count(Func<TEntity, bool>? predicate = null);
    }
}
