using Lockley.DAL.Entities;

namespace Lockley.UI.Areas.admin.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; } // Ekle-sil-güncelleme işlemler için kullanıldı.
        public IEnumerable<Category> Categories { get; set; } // Combobox içerisine doldurulmak için kullanıldı.
    }
}
