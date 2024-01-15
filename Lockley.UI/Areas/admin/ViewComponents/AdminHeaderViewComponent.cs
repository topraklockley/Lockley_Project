using Lockley.BL;
using Lockley.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lockley.UI.Areas.admin.ViewComponents
{
	[Area("admin")]
	
	public class AdminHeaderViewComponent : ViewComponent
	{
		IRepository<Category> repoCategory;

		public AdminHeaderViewComponent(IRepository<Category> _repoCategory)
		{
			repoCategory = _repoCategory;
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
