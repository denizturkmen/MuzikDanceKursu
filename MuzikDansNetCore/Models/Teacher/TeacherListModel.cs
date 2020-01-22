using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzikDansNetCore.Models.Email;


namespace MuzikDansNetCore.Models.Teacher
{
    public class TeacherListModel
    {
        public List<Entities.Teacher> Teachers { get; set; }

        public EmailModel EmailModel { get; set; }

    }
   

}
