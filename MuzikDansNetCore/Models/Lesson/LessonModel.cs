using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MuzikDansNetCore.Models.Lesson
{
    public class LessonModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Zorunlu")]
        [Display(Name = "Ders Adi")]
        public string LessonName { get; set; }

        [Required(ErrorMessage = "Zorunlu")]
        [Display(Name = "Aciklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Zorunlu")]
        //[Display(Name = "Resim Ekle")]
        //[DataType(DataType.Upload)]
        public string Images { get; set; }
    }
}
