using Lockley.BL;
using Lockley.DAL.Entities;
using Lockley.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lockley.UI.Controllers
{  
    public class HomeController : Controller
    {
        IRepository<Slide> repoSlide;
        IRepository<Product> repoProduct;

        public HomeController(IRepository<Slide> _repoSlide, IRepository<Product> _repoProduct)
        {
            repoSlide = _repoSlide;
            repoProduct = _repoProduct;
        }

        public IActionResult Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                Slides = repoSlide.GetAll().OrderBy(x => x.DisplayIndex),
                LatestProducts = repoProduct.GetAll().Include(x => x.ProductPictures).OrderBy(x => x.DisplayIndex).Take(8),
                TopSellingProducts = repoProduct.GetAll().Include(x => x.ProductPictures).Include(x => x.Category).OrderByDescending(x => x.Price).Take(8)
            };
            
            return View(indexVM);
        }
    }
}
