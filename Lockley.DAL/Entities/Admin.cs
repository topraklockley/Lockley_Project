using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class Admin
    {
        public int ID { get; set; }

        [Column(TypeName = "Varchar(20)"), StringLength(20), Display(Name = "Username"), Required(ErrorMessage = "This field cannot be empty.")]

        public string Username { get; set; }

        [Column(TypeName = "Varchar(33)"), StringLength(33), Display(Name = "Password"), Required(ErrorMessage = "This field cannot be empty.")]

        public string Password { get; set; }

        [Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name = "Full Name"), Required(ErrorMessage = "This field cannot be empty.")]

        public string FullName { get; set; }

        [Display(Name ="Last Login Date")]

        public DateTime LastLoginDate { get; set; }

        [Display(Name = "Last Login IP")]

        public string LastLoginIP { get; set; }
    }
}
