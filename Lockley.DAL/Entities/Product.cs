using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class Product
    {
        public int ID { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name ="Product Name"), Required(ErrorMessage = "This field cannot be empty.")]

        public string Name { get; set; }

		[Column(TypeName = "Varchar(250)"), StringLength(250), Display(Name = "Product Description"), Required(ErrorMessage = "This field cannot be empty.")]

		public string Description { get; set; }

		[Column(TypeName = "decimal(18,2)"), Display(Name = "Product Price"), Required(ErrorMessage ="This field cannot be empty.")]

        public decimal Price { get; set; }

        [Display(Name = "Units In Stock")]

        public int UnitsInStock { get; set; }

        [Display(Name = "Display Index"), Required(ErrorMessage = "This field cannot be empty.")]

        public int DisplayIndex { get; set; }

        [Column(TypeName = "text"), Display(Name = "Product Detail")]

        public string Detail { get; set; }

        [Column(TypeName = "text"), Display(Name = "Cargo Detail")]

        public string CargoDetail { get; set; }

        // Table Connection Properties \\
        
        [Display(Name ="Category ID")]
        
        public int? CategoryID { get; set; }
        public Category Category { get; set; }

		[Display(Name = "Brand ID")]

		public int? BrandID { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
    }
}
