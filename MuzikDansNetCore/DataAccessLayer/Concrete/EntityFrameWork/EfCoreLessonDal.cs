﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.DataAccessLayer.Abstract;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.DataAccessLayer.Concrete.EntityFrameWork
{
    public class EfCoreLessonDal:EfCoreGenericRepository<Lesson,MuzikDbContext>,ILessonDal
    {
       
    }
}
