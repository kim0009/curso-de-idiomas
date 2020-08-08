using LanguagesCourse.Configuration;
using System;
using System.Collections.Generic;

namespace LanguagesCourse.Repository.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable 
    {
        private readonly LanguagesCourseModelContext _context;

        private Dictionary<string, object> _repositories;

        private bool disposed = false;

        public UnitOfWork(LanguagesCourseModelContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            string className = typeof(T).Name;

            if (!_repositories.ContainsKey(className))
            {
                _repositories.Add(className, Activator.CreateInstance(typeof(IRepository<T>), _context));
            }
            return (IRepository<T>)_repositories[className];
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}