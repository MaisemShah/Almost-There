using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NaviStar_Tables.Data
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [Display(Name = "Department Name")]
        public string DName { get; set; }
        [Display(Name = "Department Number")]

        public string DNumber { get; set; }
    }
}
