using Lockley.DAL.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Lockley.UI.Areas.admin.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } // Ekle-sil-güncelleme işlemler için kullanıldı.
        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; } // Combobox içerisine doldurulmak için kullanıldı.
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
