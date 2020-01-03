using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikDansNetCore.Entities
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchId { get; set; }

        public string Education { get; set; }
        public string BranchName { get; set; }
        public List<Teacher> Teachers { get; set; }


    }
}
