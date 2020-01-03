using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikDansNetCore.Entities
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  LessonId { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }

      


    }
}
