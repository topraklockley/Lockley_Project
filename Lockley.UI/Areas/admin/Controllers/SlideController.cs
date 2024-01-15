using Lockley.BL;
using Lockley.DAL.Context;
using Lockley.DAL.Entities;
using Lockley.UI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Lockley.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Policy = "AdminPolicy")]

    public class SlideController : Controller
    {
        IRepository<Slide> repoSlide;

        public SlideController(IRepository<Slide> _repoSlide)
        {
            repoSlide = _repoSlide;
        }

        [Route("/admin/slide")]

        public IActionResult Index()
        {
            IQueryable slides = repoSlide.GetAll();

            return View(slides);
        }

        [Route("/admin/slide/add")]

        public IActionResult Add()
        {                      
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Insert(Slide model)
        {
			if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "slide")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "slide"));
                    }
                    string fileName = Request.Form.Files["FilePath"].FileName;

                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "slide", fileName), FileMode.Create))
                    {
                        await Request.Form.Files["FilePath"].CopyToAsync(stream);
                    }
                    model.FilePath = "/lockley/img/slide/" + fileName;
                }

                repoSlide.Add(model);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("add");
            }
        }

        public IActionResult Edit(int id)
        {
            Slide slide = repoSlide.GetBy(x => x.ID == id);

            if(slide != null)
            {               
                return View(slide);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Slide model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {                   
                    string fileName = Request.Form.Files["FilePath"].FileName;

                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lockley", "img", "slide", fileName), FileMode.Create))
                    {
                        await Request.Form.Files["FilePath"].CopyToAsync(stream);
                    }
                    model.FilePath = "/lockley/img/slide/" + fileName;
                }
                else if (TempData["TempFilePath"] != null) // LC 102006
                {
                    model.FilePath = TempData["TempFilePath"].ToString();
				}

                repoSlide.Update(model);
                
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("edit");
            }
        }

        public IActionResult Delete(int id)
        {
            Slide slide = repoSlide.GetBy(x => x.ID == id);

            if(slide != null)
            {
                repoSlide.Delete(slide);

                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
    }
}
