using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MuzikDansNetCore.Models.Teacher
{
    public class TeacherModelSocial
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Alanı Zorunlu")]
        [Display(Name = "Öğretmen Adi")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Education Alanı Zorunlu")]
        [Display(Name = "Okul Adi")]
        public string Education { get; set; }

        [Required(ErrorMessage = "Resim ekle")]
        [Display(Name = "Resim Ekle")]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }


        [Required(ErrorMessage = "Description Alanı Zorunlu")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Facebokk Alanı Zorunlu")]
        public string FacebookAdress { get; set; }

        [Required(ErrorMessage = "Twitter Alanı Zorunlu")]
        public string TwitterAdress { get; set; }

        [Required(ErrorMessage = "Instagram Alanı Zorunlu")]
        public string InstagramAdress { get; set; }


        [Required(ErrorMessage = "Branch Alanı Zorunlu")]
        public int BranchId { get; set; }
    }
}
