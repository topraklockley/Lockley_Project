using Lockley.BL;
using Lockley.DAL.Entities;
using Lockley.UI.Areas.admin.ViewModels;
using Lockley.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lockley.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Policy = "AdminPolicy")]

	public class CategoryController : Controller
	{
        IRepository<Category> repoCategory;

        public CategoryController(IRepository<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }

        [Route("/admin/category")]

        public IActionResult Index()
		{
            CategoryVM categoryVM = new CategoryVM()
            {
                Categories = repoCategory.GetAll().Include(x => x.ParentCategory).OrderBy(x => x.ParentCategory.Name).ThenBy(x => x.DisplayIndex)
			};
			
			return View(categoryVM);
		}

        [Route("/admin/category/add")]

        public IActionResult Add()
		{
            CategoryVM categoryVM = new CategoryVM()
            {
                Category = new Category(),              
                Categories = repoCategory.GetAll()
            };

            return View(categoryVM);
		}

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Insert(CategoryVM model)
        {
            if (ModelState.IsValid)
            {               
                repoCategory.Add(model.Category);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("add");
            }
        }

        public IActionResult Edit(int id)
        {
            Category category = repoCategory.GetBy(x => x.ID == id);

            if (category != null)
            {
				CategoryVM categoryVM = new CategoryVM()
				{
					Category = category,
					Categories = repoCategory.GetAll()
				};

				return View(categoryVM);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Edit(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                repoCategory.Update(model.Category);

                return RedirectToAction("index");
            }

            return RedirectToAction("edit");
        }

        public IActionResult Delete(int id)
        {
            Category category = repoCategory.GetBy(x => x.ID == id);

            if (category != null)
            {
                repoCategory.Delete(category);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
    }
}
