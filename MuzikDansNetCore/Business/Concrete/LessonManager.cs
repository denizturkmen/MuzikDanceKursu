using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.DataAccessLayer.Abstract;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public List<Lesson> GetAll()
        {
            return _lessonDal.GetAll();
        }

        public Lesson GetById(int id)
        {
            return _lessonDal.GetById(id);
        }

        public void Update(Lesson entity)
        {
            _lessonDal.Update(entity);
        }

        public void Delete(Lesson entity)
        {
            _lessonDal.Delete(entity);
        }

        public void Create(Lesson entity)
        {
            _lessonDal.Create(entity);
        }
    }
}
