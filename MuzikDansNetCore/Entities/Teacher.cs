using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikDansNetCore.Entities
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }
        public string Education { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string FacebookAdress { get; set; }
        public string TwitterAdress { get; set; }
        public string InstagramAdress { get; set; }


        public int BranchId { get; set; }
        public Branch Branch { get; set; }


        //public int LessonId { get; set; }
        //public Lesson Lesson { get; set; }


    }
}
