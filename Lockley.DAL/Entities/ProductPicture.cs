using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class ProductPicture
    {
        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name ="Product Picture Name"), Required(ErrorMessage = "This field cannot be empty.")]

        public string Name { get; set; }
        
        [Column(TypeName = "Varchar(150)"), StringLength(150), Display(Name = "Product Picture")]

        public string FilePath { get; set; }

        [Display(Name = "Display Index"), Required(ErrorMessage = "This field cannot be empty.")]

        public int DisplayIndex { get; set; }

        // Table Connection Properties \\

        [Display(Name = "Product Name")]

		public int? ProductID { get; set; }
        public Product Product { get; set; }
    }
}
