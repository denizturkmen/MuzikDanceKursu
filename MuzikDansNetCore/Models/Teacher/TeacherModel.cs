﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikDansNetCore.Models.Teacher
{
    public class TeacherModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Alanı Zorunlu")]
        [Display(Name = "Öğretmen Adi")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Education Alanı Zorunlu")]
        [Display(Name = "Okul Adi")]
        public string Education { get; set; }

       // [Required(ErrorMessage = "Image Alanı Zorunlu")]
        [Display(Name = "Resim ")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Branch Alanı Zorunlu")]
        public int BranchId { get; set; }
    }
}