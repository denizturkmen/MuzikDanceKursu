using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.Business.Abstract
{
    public interface ITeacherService
    {
        List<Teacher> GetAll();
        Teacher GetById(int id);

        void Create(Teacher entity);
        void Update(Teacher entity);
        void Delete(Teacher entity);
    }
}
