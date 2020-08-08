using LanguagesCourse.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LanguagesCourse.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LanguagesCourseModelContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(LanguagesCourseModelContext languagesCourseModelContext)
        {
            _context = languagesCourseModelContext;
            _dbSet = languagesCourseModelContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (expression != null)
            {
                query = query
                    .Where(expression);
            }
            return query;
        }
        
        public TEntity GetById(int id)
        {
            //IQueryable<TEntity> query = _dbSet;
            //var parameter = Expression.Parameter(typeof(TEntity), "x");
            //var member = Expression.Property(parameter, "Id"); 
            //var constant = Expression.Constant(id);
            //var body = Expression.Equal(member, constant); 
            //var expression = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
            return _context.Find<TEntity>(id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            foreach (string include in includes)
            {
                query.Include(include);
            }

            return query;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void SaveMany(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void UpdateMany(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.Entry(entities).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.Find<TEntity>(id);
            _context.Remove(id);
        }
    }
}