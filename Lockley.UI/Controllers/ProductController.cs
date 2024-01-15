using Lockley.BL;
using Lockley.DAL.Entities;
using Lockley.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lockley.UI.Controllers
{
	public class ProductController : Controller
	{
		IRepository<Product> repoProduct;

        public ProductController(IRepository<Product> _repoProduct)
        {
			repoProduct = _repoProduct;
        }

        public IActionResult Index()
		{
			return View();
		}

		[Route("/product/{name}-{id}")]

		public IActionResult Detail(string name, int id)
		{
			Product product = repoProduct.GetAll(x => x.ID == id).Include(x => x.ProductPictures).Include(x => x.Category).ThenInclude(x => x.ParentCategory).FirstOrDefault();

			if(product != null)
			{
				ProductVM productVM = new ProductVM()
				{
					Product = product,
					RelatedProducts = repoProduct.GetAll(x => x.ID != product.ID && x.Category.ParentID == product.Category.ParentID).Include(x => x.Category).Include(x => x.ProductPictures)
				};
				return View(productVM);
			}
			else
			{
				return View();
			}
		}
	}
}
