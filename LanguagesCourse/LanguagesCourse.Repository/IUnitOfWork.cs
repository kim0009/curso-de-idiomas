namespace LanguagesCourse.Repository.Base
{
    public interface IUnitOfWork 
    {
        void Commit();

        IRepository<T> GetRepository<T>() where T : class;
    }
}