using Lockley.BL;
using Lockley.DAL.Context;
using Lockley.DAL.Entities;
using Lockley.UI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lockley.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Policy = "AdminPolicy")]

    public class BrandController : Controller
    {
        IRepository<Brand> repoBrand;

        public BrandController(IRepository<Brand> _repoBrand)
        {
            repoBrand = _repoBrand;
        }

        [Route("/admin/brand")]
        
        public IActionResult Index()
        {
			BrandVM brandVM = new BrandVM()
			{
				Brands = repoBrand.GetAll(),
			};

			return View(brandVM);
		}

        [Route("/admin/brand/add")]

        public IActionResult Add()
        {                      
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Insert(BrandVM model)
        {
            if (ModelState.IsValid)
            {              
                repoBrand.Add(model.Brand);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("add");
            }
        }
        
        public IActionResult Edit(int id)
        {
            Brand brand = repoBrand.GetBy(x => x.ID == id);

            if(brand != null)
            {
                BrandVM brandVM = new BrandVM()
                {
                    Brand = brand,
                    Brands = repoBrand.GetAll().OrderBy(x => x.Name)
                };
                
                return View(brandVM);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Edit(BrandVM model)
        {
            if(ModelState.IsValid)
            {               
                repoBrand.Update(model.Brand);
                
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("edit");
            }
        }

        public IActionResult Delete(int id)
        {
            Brand brand = repoBrand.GetBy(x => x.ID == id);

            if(brand != null)
            {
                repoBrand.Delete(brand);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
    }
}
