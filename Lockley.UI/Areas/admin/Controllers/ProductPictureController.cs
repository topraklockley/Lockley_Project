using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lockley.DAL.Entities;
using Lockley.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.VisualBasic.FileIO;

namespace Lockley.UI.Areas.admin.Controllers
{
	[Area("admin"), Authorize(Policy = "AdminPolicy")]
	
	public class ProductPictureController : Controller
	{
		IRepository<ProductPicture> repoProductPicture;
        IRepository<Product> repoProduct;

        public ProductPictureController(IRepository<ProductPicture> _repoProductPicture, IRepository<Product> _repoProduct)
		{
			repoProductPicture = _repoProductPicture;
            repoProduct = _repoProduct;
		}

		[Route("/admin/productpicture/index/{productid}")]

        public IActionResult Index(int productid)
		{
            Product product = repoProduct.GetBy(x => x.ID == productid);
            
            ViewBag.ProductID = productid;
            ViewBag.ProductName = product.Name;

			IQueryable<ProductPicture> productPictures = repoProductPicture.GetAll(x => x.ProductID == productid);
			
			return View(productPictures);
		}

        [Route("/admin/productpicture/add/{productid}")]

        public IActionResult Add(int productid)
		{
            ViewBag.ProductID = productid;
            
            return View();
		}
        
        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Insert(ProductPicture model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "productpicture")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "productpicture"));
                    }				
                    string fileName = Request.Form.Files["FilePath"].FileName;

					using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "productpicture", fileName), FileMode.Create))
                    {
                        await Request.Form.Files["FilePath"].CopyToAsync(stream);
                    }
                    model.FilePath = "/lockley/img/productpicture/" + fileName;
                }
             
                repoProductPicture.Add(model);

                return RedirectToAction("index", new {productid = model.ProductID});
            }
            else
            {
                return RedirectToAction("add");
            }
        }

        public IActionResult Edit(int productid, int id)
		{
            ViewBag.ProductID = productid;

            ProductPicture productpicture = repoProductPicture.GetBy(x => x.ID == id);

            return View(productpicture);
		}

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(ProductPicture model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    string fileName = Request.Form.Files["FilePath"].FileName;

                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "productpicture", fileName), FileMode.Create))
                    {
                        await Request.Form.Files["FilePath"].CopyToAsync(stream);
                    }
                    model.FilePath = "/lockley/img/productpicture/" + fileName;
                }

                repoProductPicture.Update(model);

                return RedirectToAction("index", new { productid = model.ProductID });
            }
            else
            {
                return RedirectToAction("edit", new { productid = model.ProductID, id = model.ID });
            }
        }

		[Route("/admin/productpicture/delete/{productid}/{id}")]

		public IActionResult Delete(int productid, int id)
        {
            ProductPicture productpicture = repoProductPicture.GetBy(x => x.ID == id);

            if(productpicture != null)
            {
                repoProductPicture.Delete(productpicture);
            }

            return RedirectToAction("index", new { productid = productid });
        }
    }
}
