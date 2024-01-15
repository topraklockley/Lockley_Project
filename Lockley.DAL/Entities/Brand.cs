using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class Brand
    {
        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name ="Brand Name"), Required(ErrorMessage ="This field cannot be empty.")]

        public string Name { get; set; }

        // Table Connection Properties \\

        public ICollection<Product> Products { get; set; }
    }
}
