using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class Category
    {
        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name ="Category Name"), Required(ErrorMessage = "This field cannot be empty.")]

        public string Name { get; set; }

        [Display(Name = "Display Index"), Required(ErrorMessage = "This field cannot be empty.")]

        public int DisplayIndex { get; set; }

        // Table Connection Properties \\

        [Display(Name = "Up Category Name")]

        public int? ParentID { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
