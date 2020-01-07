using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikDansNetCore.Models.Branch
{
    public class BranchModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zorunlu")]
        [Display(Name = "Brans Adi")]
        public string BranchName { get; set; }
    }
}
