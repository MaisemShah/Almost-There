using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NaviStar_Tables.Data
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EID { get; set; }
        [Display(Name = "First Name")]
        public string FN { get; set; }
        [Display(Name = "Last Name")]
        public string LN { get; set; }
        public DateTime Date { get; set; }
        public string Approved { get; set; }
        public string UserRoleID { get; set; }
        public int DID { get; set; }
        [ForeignKey("DID")]
        public Department Departments { get; set; }
        public int  AID { get; set; }
        [ForeignKey("AID")]
        public Audit AudID { get; set; }
        public int USRID { get; set; }
        [ForeignKey("USRID")]
        public UserRole UserRoles { get; set; }
    }
}
