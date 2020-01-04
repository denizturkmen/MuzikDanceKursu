using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.DataAccessLayer.Abstract;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.Business.Concrete
{
    public class TeacherManager :ITeacherService
    {
        private ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public List<Teacher> GetAll()
        {
            return _teacherDal.GetAll();
        }

        public Teacher GetById(int id)
        {
            return _teacherDal.GetById(id);
        }

        public void Create(Teacher entity)
        {
            _teacherDal.Create(entity);
        }

        public void Update(Teacher entity)
        {
            _teacherDal.Update(entity);
        }

        public void Delete(Teacher entity)
        {
            _teacherDal.Delete(entity);
        }
    }
}
