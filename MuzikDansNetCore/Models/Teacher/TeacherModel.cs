using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.Models.Teacher
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Öğretmen ismi girilmesi mecburi alan")]
        [Display(Name = "Öğretmen Adi")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter olabilir" )]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Öğrenim alanı zorunludur")]
        [Display(Name = "Okul Ismi")]
        public string Education { get; set; }

        [Required(ErrorMessage = "Resim alanı zorunludur")]
        [Display(Name = "Resim Ekle")]
        public string Image { get; set; }

        public int BranchId { get; set; }


       
    }
}
