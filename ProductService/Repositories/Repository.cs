using Microsoft.EntityFrameworkCore;

namespace ProductService.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            //_dbSet.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            return _dbSet.Update(entity).Entity;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
