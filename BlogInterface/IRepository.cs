using BlogEntity;
using System.Collections.Generic;

namespace BlogInterface
{
    public interface IRepository <TEntity> where TEntity : Entity
    {
        
        List<TEntity> GetAll();
        TEntity Get(int id);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        
    }
}
