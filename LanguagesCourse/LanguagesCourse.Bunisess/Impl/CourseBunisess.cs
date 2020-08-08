using LanguagesCourse.Entity;
using LanguagesCourse.Model.Dto;
using LanguagesCourse.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public CourseDto GetById(int id)
        {
            _unitOfWork.GetRepository<Course>().GetById(id);
            return null;
        }
    }
}