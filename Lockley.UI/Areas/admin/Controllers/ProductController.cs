using Lockley.BL;
using Lockley.DAL.Entities;
using Lockley.UI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lockley.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Policy = "AdminPolicy")]

    public class ProductController : Controller
    {
        IRepository<Product> repoProduct;
		IRepository<Category> repoCategory;
		IRepository<Brand> repoBrand;
        
        public ProductController(IRepository<Product> _repoProduct, IRepository<Category> _repoCategory, IRepository<Brand> _repoBrand)
        {
            repoProduct = _repoProduct;
			repoCategory = _repoCategory;
			repoBrand = _repoBrand;
        }

        [Route("/admin/product")]

        public IActionResult Index()
        {                                  
            ProductVM productVM = new ProductVM()
            {
                Products = repoProduct.GetAll().Include(x => x.Category).Include(x => x.Brand),
                Categories = repoCategory.GetAll(),
            };
			
            return View(productVM);
        }

        [Route("/admin/product/add")]

        public IActionResult Add()
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
				Categories = repoCategory.GetAll(),
				Brands = repoBrand.GetAll()         
            };
            
            return View(productVM);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Insert(ProductVM model)
        {
            if (ModelState.IsValid)
            {                 
                repoProduct.Add(model.Product);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("add");
            }
        }

        public IActionResult Edit(int id)
        {
			Product product = repoProduct.GetBy(x => x.ID == id);

            if(product != null)
            {
                ProductVM productVM = new ProductVM()
                {
                    Product = product,
                    Products = repoProduct.GetAll(),
                    Categories = repoCategory.GetAll(),
                    Brands = repoBrand.GetAll()
				};
                
                return View(productVM);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Edit(ProductVM model)
        {
            if(ModelState.IsValid)
            {                
                repoProduct.Update(model.Product);
                
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("edit");
            }
        }

        public IActionResult Delete(int id)
        {
			Product product = repoProduct.GetBy(x => x.ID == id);

            if(product != null)
            {
                repoProduct.Delete(product);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
    }
}
