using Lockley.DAL.Entities;

namespace Lockley.UI.Areas.admin.ViewModels
{
    public class BrandVM
    {
        public Brand Brand { get; set; } // Ekle-sil-güncelleme işlemler için kullanıldı.
        public IEnumerable<Brand> Brands { get; set; } // Combobox içerisine doldurulmak için kullanıldı.
	}
}
