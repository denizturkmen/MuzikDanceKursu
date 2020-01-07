using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikDansNetCore.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı Adinizi giriniz")]
        [Display(Name = "Kullanici Adi")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz ")]
        [Display(Name = "Şifre")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
