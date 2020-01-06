using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.Business.Abstract
{
    public interface ILessonService
    {
        List<Lesson> GetAll();
        Lesson GetById(int id);

        void Update(Lesson entity);
        void Delete(Lesson entity);
        void Create(Lesson entity);

    }
}
