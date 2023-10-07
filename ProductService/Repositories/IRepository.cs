namespace ProductService.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        void Save();
    }
}
