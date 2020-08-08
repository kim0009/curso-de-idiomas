using LanguagesCourse.Entity;
using LanguagesCourse.Repository.Base;
using System.Collections.Generic;
using System.Linq;

namespace LanguagesCourse.Bunisess.Impl
{
    public class CourseBunisess : ICourseBunisess
    {
        public readonly IUnitOfWork _unitOfWork;

        public CourseBunisess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckExistence(int id)
        {
            IQueryable<Course> query = _unitOfWork.GetRepository<Course>().Get(x => x.Id == id);
            return query.Any();
        }

        public Course GetById(int id)
        {
            return _unitOfWork.GetRepository<Course>().GetById(id);
        }

        public List<Course> GetAll()
        {
            var repository = _unitOfWork.GetRepository<Course>();
            return repository.Get(includes: "StudentHistory").ToList();
        }
        public void Save(Course course)
        {
            var repository = _unitOfWork.GetRepository<Course>();
            repository.Save(course);
            _unitOfWork.Commit();
        }

        public void Update(Course course)
        {
            var repository = _unitOfWork.GetRepository<Course>();
            repository.Update(course);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Course>().Delete(id);
            _unitOfWork.Commit();
        }
    }
}