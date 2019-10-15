using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NaviStar_Tables.Data
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int USRID { get; set; }
        [Display(Name ="UserName")]
        public string UserN{ get; set; }
        [Display(Name = "User Location")]

        public string UserL { get; set; }

    }
}
