using Lockley.BL;
using Lockley.BL.Tools;
using Lockley.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lockley.UI.Controllers
{
	public class CategoryController : Controller
	{
		IRepository<Category> repoCategory;

        public CategoryController(IRepository<Category> _repoCategory)
        {
			repoCategory = _repoCategory;
        }

        public IActionResult Index()
		{
			return View();
		}

		[Route("{catname}/{subcatname}-{subcatid}")]

		public IActionResult Filter(int subcatid)
		{
			Category filteredCategory = repoCategory.GetAll(x => x.ID == subcatid).Include(x => x.Products).ThenInclude(x => x.ProductPictures).FirstOrDefault();

			return View(filteredCategory);
		}
	}
}
