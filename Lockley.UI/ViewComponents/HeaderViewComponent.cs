using Lockley.BL;
using Lockley.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Lockley.UI.ViewComponents
{
	public class HeaderViewComponent : ViewComponent
	{
		IRepository<Category> repoCategory;

        public HeaderViewComponent(IRepository<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }

        public IViewComponentResult Invoke()
		{
			if (User.Identity.IsAuthenticated)
			{
				if(User.Identity.AuthenticationType == "AdminAuthorization")
				{
					if (User.Identity.Name == "Toprak Lockley")
					{
						ViewBag.AuthLevel = 3; // Boss Level
					}
					else
					{
						ViewBag.AuthLevel = 2; // Admin Level
					}				
				}
				else
				{
                    ViewBag.AuthLevel = 1; // Member Level
                }
            }
			else
			{
				ViewBag.AuthLevel = 0; // Guest Level
			}
			
			var orderedByIndex = repoCategory.GetAll().Include(x => x.SubCategories).OrderBy(x => x.DisplayIndex);
			
			return View(orderedByIndex);
		}
	}
}
