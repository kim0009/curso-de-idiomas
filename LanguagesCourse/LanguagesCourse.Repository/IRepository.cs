using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LanguagesCourse.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null, params string[] includes);

        TEntity GetById(int id);

        void Save(TEntity entity);
        
        void SaveMany(ICollection<TEntity> entities);
        
        void Update(TEntity entity);
        
        void UpdateMany(ICollection<TEntity> entities);

        void Delete(int id);
    }
}