using BlogEntity;
using BlogInterface;
using BlogData;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BlogRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private BlogDBContext context = new BlogDBContext();

        public BlogDBContext Context
        {
            get { return this.context; }
        }

        public List<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            return this.context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            return this.context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            return this.context.SaveChanges();
        }
    }
}
